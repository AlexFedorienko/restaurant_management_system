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
        }

        private void InitializeCustomComponents()
        {
            // Настройка основной формы
            this.BackColor = Color.FromArgb(48, 57, 76);
            this.ClientSize = new Size(1280, 720);
            this.FormBorderStyle = FormBorderStyle.None;

            // Создаем и настраиваем график
            revenueChart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(20, 100, 20, 20) // Увеличили верхний отступ
            };
            this.Controls.Add(revenueChart);

            // Панель управления с кнопками (слева)
            var controlPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(24, 26, 51),
                Padding = new Padding(20, 15, 20, 15)
            };

            // Контейнер для элементов выбора дат (теперь слева и шире)
            var datePanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 600,  // Увеличили ширину
                BackColor = Color.Transparent
            };

            // Метки "С:" и "По:" - увеличенные и жирные
            var labelFrom = new Label
            {
                Text = "Период с:",
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold), // Увеличили шрифт
                Location = new Point(20, 20),
                AutoSize = true
            };

            var labelTo = new Label
            {
                Text = "по:",
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold), // Увеличили шрифт
                Location = new Point(320, 20), // Сдвинули правее
                AutoSize = true
            };

            // Поля выбора дат - увеличенные
            dateFromPicker = new DateTimePicker
            {
                Width = 200,  // Увеличили ширину
                Height = 35,   // Увеличили высоту
                Location = new Point(120, 18), // Сдвинули правее
                Format = DateTimePickerFormat.Short,
                Font = new Font("Arial", 12) // Увеличили шрифт
            };

            dateToPicker = new DateTimePicker
            {
                Width = 200,
                Height = 35,
                Location = new Point(360, 18), // Сдвинули правее
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today,
                Font = new Font("Arial", 12) // Увеличили шрифт
            };

            // Кнопка - увеличенная и стилизованная
            var loadButton = new Button
            {
                Text = "ПОКАЗАТЬ",
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 40), // Увеличили размер
                Location = new Point(580, 15), // Сдвинули правее
                Font = new Font("Arial", 12, FontStyle.Bold) // Увеличили шрифт
            };
            loadButton.Click += (s, e) => LoadRevenueData(dateFromPicker.Value, dateToPicker.Value);

            // Добавляем элементы в панель
            datePanel.Controls.Add(labelFrom);
            datePanel.Controls.Add(dateFromPicker);
            datePanel.Controls.Add(labelTo);
            datePanel.Controls.Add(dateToPicker);
            datePanel.Controls.Add(loadButton);

            controlPanel.Controls.Add(datePanel);
            this.Controls.Add(controlPanel);

            // Инициализация графика
            InitializeChart();
        }

        private void InitializeChart()
        {
            revenueChart.ChartAreas.Clear();
            revenueChart.Series.Clear();

            // Настройка области графика
            ChartArea chartArea = new ChartArea("MainArea")
            {
                AxisX =
                {
                    Title = "Дата",
                    TitleFont = new Font("Arial", 12, FontStyle.Bold),
                    Interval = 1,
                    LabelStyle = { Angle = -45, Format = "dd.MM", Font = new Font("Arial", 10) }
                },
                AxisY =
                {
                    Title = "Сумма ($)",
                    TitleFont = new Font("Arial", 12, FontStyle.Bold),
                    LabelStyle = { Format = "C0", Font = new Font("Arial", 10) }
                },
                BackColor = Color.White
            };
            revenueChart.ChartAreas.Add(chartArea);

            // Добавление серии данных
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

                // Автомасштабирование
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
            // Загрузка данных за последние 30 дней по умолчанию
            dateFromPicker.Value = DateTime.Today.AddDays(-30);
            dateToPicker.Value = DateTime.Today;
            LoadRevenueData(dateFromPicker.Value, dateToPicker.Value);
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1 = new Form1(userName, userId);
            form1.Show();
        }
    }
}