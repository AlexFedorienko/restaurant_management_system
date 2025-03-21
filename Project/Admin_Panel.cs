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

            MenuList.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            MenuList.Columns["Name"].Width = 200;
            MenuList.Columns["Image"].Width = 230;
            MenuList.RowTemplate.Height = 200;


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
                if (row.Cells["Image"].Value != null)
                {
                    if (row.Cells["Image"].Value is byte[] imageData)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            Image originalImage = Image.FromStream(ms);
                            int desiredWidth = 230;
                            int desiredHeight = 200;
                            row.Cells["Image"].Value = originalImage.GetThumbnailImage(desiredWidth, desiredHeight, null, IntPtr.Zero);
                        }
                    }
                }

                dataBase.closeConnection();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form1 = new Form1(userName, userId);
            form1.Show();
        }
    }
}