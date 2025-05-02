using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class Revenue : Form
    {
        private DataBase dataBase = new DataBase();
        private Form1 form1;
        private string userName;
        private int userId;
        private Chart revenueChart;
        private DateTimePicker dateFromPicker;
        private DateTimePicker dateToPicker;

        public Revenue(string userName, int userId)
        {
            InitializeComponent();
            this.userName = userName;
            this.userId = userId;
            InitializeCustomComponents();
            SetupEventHandlers();
        }

        private void InitializeCustomComponents()
        {
            this.BackColor = Color.FromArgb(48, 57, 76);
            this.ClientSize = new Size(1280, 720);
            this.FormBorderStyle = FormBorderStyle.None;

            revenueChart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(20, 120, 20, 20) // Увеличил верхний отступ для графика
            };
            this.Controls.Add(revenueChart);

            var controlPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120, // Увеличил высоту панели управления
                BackColor = Color.FromArgb(24, 26, 51),
                Padding = new Padding(20, 15, 20, 15)
            };

            var datePanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 780,
                BackColor = Color.Transparent
            };

            var labelFrom = new Label
            {
                Text = "Период с:",
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(225, 15), // Поднял немного выше
                AutoSize = true
            };

            var labelTo = new Label
            {
                Text = "по:",
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(545, 15), // Поднял немного выше
                AutoSize = true
            };

            dateFromPicker = new DateTimePicker
            {
                Width = 200,
                Height = 35,
                Location = new Point(335, 12), // Поднял немного выше
                Format = DateTimePickerFormat.Short,
                Font = new Font("Arial", 12)
            };

            dateToPicker = new DateTimePicker
            {
                Width = 200,
                Height = 35,
                Location = new Point(585, 12), // Поднял немного выше
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today,
                Font = new Font("Arial", 12)
            };

            // Настройка кнопки Show
            loadButton.Location = new Point(335, 55); // Расположил кнопку ниже дат
            loadButton.Size = new Size(180, 35);
            loadButton.FlatStyle = FlatStyle.Flat;
            loadButton.Text = "Show";

            datePanel.Controls.Add(labelFrom);
            datePanel.Controls.Add(dateFromPicker);
            datePanel.Controls.Add(labelTo);
            datePanel.Controls.Add(dateToPicker);
            datePanel.Controls.Add(loadButton);

            controlPanel.Controls.Add(datePanel);
            this.Controls.Add(controlPanel);

            InitializeChart();
        }

        private void SetupEventHandlers()
        {
            loadButton.Click += LoadButton_Click;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadRevenueData(dateFromPicker.Value, dateToPicker.Value);
        }

        private void InitializeChart()
        {
            revenueChart.ChartAreas.Clear();
            revenueChart.Series.Clear();

            ChartArea chartArea = new ChartArea("MainArea")
            {
                AxisX = {
                    Title = "Дата",
                    TitleFont = new Font("Arial", 12, FontStyle.Bold),
                    Interval = 1,
                    LabelStyle = { Angle = -45, Format = "dd.MM", Font = new Font("Arial", 10) }
                },
                AxisY = {
                    Title = "Сумма ($)",
                    TitleFont = new Font("Arial", 12, FontStyle.Bold),
                    LabelStyle = { Format = "C0", Font = new Font("Arial", 10) }
                },
                BackColor = Color.White
            };
            revenueChart.ChartAreas.Add(chartArea);

            Series series = new Series("Revenue")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SeaGreen,
                IsValueShownAsLabel = true,
                LabelFormat = "C0",
                Font = new Font("Arial", 10, FontStyle.Bold),
                BorderWidth = 2
            };
            revenueChart.Series.Add(series);
        }

        private void LoadRevenueData(DateTime fromDate, DateTime toDate)
        {
            try
            {
                dataBase.openConnection();

                string query = @"
                    SELECT 
                        CONVERT(date, OrderDate) AS OrderDate,
                        SUM(TotalAmount) AS DailyRevenue
                    FROM Orders
                    WHERE OrderDate BETWEEN @FromDate AND @ToDate
                    GROUP BY CONVERT(date, OrderDate)
                    ORDER BY OrderDate";

                SqlCommand cmd = new SqlCommand(query, dataBase.getConnection());
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate.AddDays(1));

                revenueChart.Series["Revenue"].Points.Clear();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        decimal revenue = reader.GetDecimal(1);

                        DataPoint point = new DataPoint();
                        point.SetValueXY(date.ToString("dd.MM"), revenue);
                        point.Label = revenue.ToString("C0");
                        revenueChart.Series["Revenue"].Points.Add(point);
                    }
                }

                revenueChart.Titles.Clear();
                revenueChart.Titles.Add(new Title(
                    $"Доход за период: {fromDate:dd.MM.yyyy} - {toDate:dd.MM.yyyy}",
                    Docking.Top,
                    new Font("Arial", 14, FontStyle.Bold),
                    Color.Black));

                revenueChart.ChartAreas["MainArea"].RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dateFromPicker.Value = DateTime.Today.AddDays(-30);
            dateToPicker.Value = DateTime.Today;
            LoadRevenueData(dateFromPicker.Value, dateToPicker.Value);
        }

        private void quit_Click(object sender, EventArgs e)
        {
            form1 = new Form1(userName, userId);
            form1.Show();
            this.Hide();
        }
    }
}