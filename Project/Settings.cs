using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Settings : Form
    {
        DataBase dataBase = new DataBase();
        private Form1 mainForm;

        public Settings(Form1 form1)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            mainForm = form1;
        }

        private void SaveImageToDatabase(byte[] imageBytes)
        {
            string query = "UPDATE auth SET image_user = @image WHERE id = @userId";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = Auth.UserId;

            dataBase.openConnection();

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Image uploaded successfully.");
                mainForm.LoadUserImage(Auth.UserId); // Обновляем фото в Form1
            }
            else
            {
                MessageBox.Show("Error uploading image.");
            }
            dataBase.closeConnection();
        }

        private void btnEnterUploadImageWs_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                SaveImageToDatabase(imageBytes);
            }
        }
    }
}
