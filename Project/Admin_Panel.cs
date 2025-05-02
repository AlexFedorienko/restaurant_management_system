using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Admin_Panel : Form
    {
        private DataBase dataBase = new DataBase();
        private Form1 form1;
        private string userName;
        private int userId;
        private byte[] imageBytes;
        private Panel previewPanel;
        private Label labelPreview;

        public Admin_Panel()
        {
            InitializeComponent();
        }

        public Admin_Panel(string userName, int userId)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.userName = userName;
            this.userId = userId;
            LoadMenuItems();

            labelPreview = new Label
            {
                Text = "Preview",
                Font = new Font("Century Gothic", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(10, 10)
            };

            previewPanel = new Panel
            {
                Size = new Size(162, 230),
                Location = new Point(457, 150),
                BackColor = Color.FromArgb(48, 57, 76),
                BorderStyle = BorderStyle.None
            };

            previewPanel.Paint += PreviewPanel_Paint;
            previewPanel.Controls.Add(labelPreview);
            Controls.Add(previewPanel);
        }

        private void LoadMenuItems()
        {
            dataBase.openConnection();
            string query = "SELECT * FROM Menu";
            SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);
            MenuList.DataSource = table;

            // Стилизация таблицы
            MenuList.BackgroundColor = Color.FromArgb(48, 57, 76);
            MenuList.GridColor = Color.FromArgb(70, 80, 100);
            MenuList.BorderStyle = BorderStyle.None;
            MenuList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            MenuList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MenuList.EnableHeadersVisualStyles = false;
            MenuList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 50);
            MenuList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            MenuList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 15, FontStyle.Bold);
            MenuList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MenuList.DefaultCellStyle.BackColor = Color.FromArgb(60, 70, 90);
            MenuList.DefaultCellStyle.ForeColor = Color.White;
            MenuList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 110, 130);
            MenuList.DefaultCellStyle.SelectionForeColor = Color.White;
            MenuList.DefaultCellStyle.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            MenuList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MenuList.RowHeadersVisible = false;
            MenuList.AllowUserToAddRows = false;
            MenuList.AllowUserToResizeRows = false;
            MenuList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (MenuList.Columns.Contains("id"))
                MenuList.Columns["id"].Visible = false;

            comboBoxNames.Items.Clear();
            foreach (DataRow row in table.Rows)
                comboBoxNames.Items.Add(row["Name"].ToString());

            if (!MenuList.Columns.Contains("Image"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                MenuList.Columns.Add(imgCol);
            }

            foreach (DataGridViewRow row in MenuList.Rows)
            {
                if (row.Cells["Image"].Value is byte[] imageData)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image originalImage = Image.FromStream(ms);
                        row.Cells["Image"].Value = originalImage.GetThumbnailImage(200, 150, null, IntPtr.Zero);
                    }
                }
            }

            MenuList.RowTemplate.Height = 150;
            dataBase.closeConnection();
        }

        private void UpdatePreview()
        {
            previewPanel.Controls.Clear();
            previewPanel.Controls.Add(labelPreview);

            if (imageBytes != null)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(120, 100),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point((previewPanel.Width - 120) / 2, labelPreview.Bottom + 10)
                };

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }

                Label labelName = new Label
                {
                    Text = textBoxName.Text,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(150, 30),
                    Font = new Font("Century Gothic", 15, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point((previewPanel.Width - 150) / 2, pictureBox.Bottom + 5)
                };

                Label labelPrice = new Label
                {
                    Text = "$" + textBoxPrice.Text,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(150, 30),
                    Font = new Font("Century Gothic", 15, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point((previewPanel.Width - 150) / 2, labelName.Bottom + 5)
                };

                previewPanel.Controls.Add(pictureBox);
                previewPanel.Controls.Add(labelName);
                previewPanel.Controls.Add(labelPrice);
            }
            else
            {
                labelPreview.Visible = false;
            }
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                UpdatePreview();
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (imageBytes == null)
            {
                MessageBox.Show("Please select an image.");
                return;
            }

            SqlCommand command = new SqlCommand("INSERT INTO Menu (Name, Description, Price, Image) VALUES (@Name, @Description, @Price, @Image)", dataBase.getConnection());
            command.Parameters.AddWithValue("@Name", textBoxName.Text);
            command.Parameters.AddWithValue("@Description", textBoxDescription.Text);
            command.Parameters.AddWithValue("@Price", double.Parse(textBoxPrice.Text));
            command.Parameters.AddWithValue("@Image", imageBytes);

            dataBase.openConnection();
            command.ExecuteNonQuery();
            dataBase.closeConnection();

            LoadMenuItems();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxNames.SelectedItem == null)
            {
                MessageBox.Show("Выберите название для удаления.");
                return;
            }

            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Menu WHERE Name = @Name", dataBase.getConnection());
            deleteCommand.Parameters.AddWithValue("@Name", comboBoxNames.SelectedItem.ToString());

            dataBase.openConnection();
            deleteCommand.ExecuteNonQuery();
            dataBase.closeConnection();

            LoadMenuItems();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e) => UpdatePreview();

        private void textBoxPrice_TextChanged(object sender, EventArgs e) => UpdatePreview();

        private void PreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(24, 26, 51), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, previewPanel.Width - 1, previewPanel.Height - 1);
            }
        }

        private void buttonActiveOrdersAP_Click(object sender, EventArgs e)
        {
            new Orders_Panel(userName, userId).Show();
            this.Hide();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            form1 = new Form1(userName, userId);
            form1.Show();
            this.Hide();
        }

        private void buttonBookingAP_Click(object sender, EventArgs e)
        {
            new UsersList(userName, userId).Show();
            this.Hide();
        }

        private void buttonMoneyCostAP_Click(object sender, EventArgs e)
        {
            new Revenue(userName, userId).Show();
            this.Hide();
        }
    }
}