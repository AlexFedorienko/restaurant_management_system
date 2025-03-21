using System;
using System.Collections.Generic;
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
        }

        private void LoadMenuItems()
        {
            dataBase.openConnection();
            string query = "SELECT * FROM Menu";
            SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);
            MenuList.DataSource = table;

            if (!MenuList.Columns.Contains("Image"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "Image";
                imgCol.HeaderText = "Image";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // Используем Zoom для масштабирования
                MenuList.Columns.Add(imgCol);
            }

            // Устанавливаем высоту строки, чтобы фото не были сжатыми
            foreach (DataGridViewRow row in MenuList.Rows)
            {
                row.Height = 150; // Устанавливаем нужную высоту для отображения изображений
            }

            foreach (DataGridViewRow row in MenuList.Rows)
            {
                if (row.Cells["Image"].Value != null)
                {
                    if (row.Cells["Image"].Value is byte[] imageData)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            row.Cells["Image"].Value = Image.FromStream(ms);
                        }
                    }
                    else if (row.Cells["Image"].Value is Bitmap image)
                    {
                        row.Cells["Image"].Value = image;
                    }
                }
            }

            dataBase.closeConnection();
        }



        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                imageBytes = File.ReadAllBytes(imagePath);
                pictureBoxPreview.Image = Image.FromFile(imagePath);
                pictureBoxPreview.Visible = true;
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string description = textBoxDescription.Text;
            double price = double.Parse(textBoxPrice.Text);

            if (imageBytes == null)
            {
                MessageBox.Show("Пожалуйста, выберите изображение.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form1 = new Form1(userName, userId);
            form1.Show();
        }
    }
}
