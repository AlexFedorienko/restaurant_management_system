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

            MenuList.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            MenuList.Columns["Name"].Width = 150;
            MenuList.Columns["Image"].Width = 200;
            MenuList.RowTemplate.Height = 150;

            if (MenuList.Columns.Contains("id"))
            {
                MenuList.Columns["id"].Visible = false;
            }

            comboBoxNames.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                comboBoxNames.Items.Add(row["Name"].ToString());
            }

            if (!MenuList.Columns.Contains("Image"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "Image";
                imgCol.HeaderText = "Image";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                MenuList.Columns.Add(imgCol);
            }

            foreach (DataGridViewRow row in MenuList.Rows)
            {
                if (row.Cells["Image"].Value != null && row.Cells["Image"].Value is byte[] imageData)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image originalImage = Image.FromStream(ms);
                        int desiredWidth = 200;
                        int desiredHeight = 150;
                        row.Cells["Image"].Value = originalImage.GetThumbnailImage(desiredWidth, desiredHeight, null, IntPtr.Zero);
                    }
                }
            }

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                imageBytes = File.ReadAllBytes(imagePath);
                UpdatePreview();
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string description = textBoxDescription.Text;
            double price = double.Parse(textBoxPrice.Text);

            if (imageBytes == null)
            {
                MessageBox.Show("Please select an image.");
                return;
            }

            string query = "INSERT INTO Menu (Name, Description, Price, Image) VALUES (@Name, @Description, @Price, @Image)";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@Price", price);
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

            string name = comboBoxNames.SelectedItem.ToString();

            string deleteQuery = "DELETE FROM Menu WHERE Name = @Name";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, dataBase.getConnection());
            deleteCommand.Parameters.AddWithValue("@Name", name);

            dataBase.openConnection();
            deleteCommand.ExecuteNonQuery();
            dataBase.closeConnection();

            LoadMenuItems();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void PreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(24, 26, 51), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, previewPanel.Width - 1, previewPanel.Height - 1);
            }
        }

        private void buttonActiveOrdersAP_Click(object sender, EventArgs e)
        {
            Orders_Panel orders_Panel = new Orders_Panel(userName, userId);
            orders_Panel.Show();
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
            UsersList usersList = new UsersList(userName, userId);  
            usersList.Show();   
            this.Hide();
        }
    }
}