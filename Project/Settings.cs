using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Settings : Form
    {
        DataBase dataBase = new DataBase();
        private Form1 form1;
        Auth auth = new Auth();

        private Form1 mainForm;
        private string originalLogin;
        private string originalEmail;
        private string originalPassword;

        public Settings(Form1 form1)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            mainForm = new Form1(Auth.UserName, Auth.UserId);

            LoadUserData(Auth.UserId);
            LoadUserImage(Auth.UserId);

            MakePictureBoxRound(UserImage);
            MakeButtonRound(PensilButton, 20);

            this.form1 = form1;
        }

        private void LoadUserData(int userId)
        {
            string query = $"SELECT login_user, email_user, password_user FROM auth WHERE id = {userId}";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                originalLogin = reader["login_user"].ToString();
                originalEmail = reader["email_user"].ToString();
                originalPassword = reader["password_user"].ToString();

                textBoxLoginS.Text = originalLogin;
                textBoxEmailS.Text = originalEmail;
                textBoxPasswordS.Text = originalPassword;
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void SaveExitButton_Click(object sender, EventArgs e)
        {
            string newLogin = textBoxLoginS.Text;
            string newEmail = textBoxEmailS.Text;
            string newPassword = textBoxPasswordS.Text;

            if (newLogin == originalLogin && newEmail == originalEmail && newPassword == originalPassword)
            {
                this.Close();
                return;
            }

            string query = $"UPDATE auth SET login_user = '{newLogin}', email_user = '{newEmail}', password_user = '{newPassword}' WHERE id = {Auth.UserId}";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data updated successfully.");
            }
            else
            {
                MessageBox.Show("Error updating data.");
            }
            dataBase.closeConnection();

            auth.Show();
            this.Close();
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
                mainForm.UpdateUserImage();
            }
            else
            {
                MessageBox.Show("Error uploading image.");
            }
            dataBase.closeConnection();
        }


        private void MakeButtonRound(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius - 1, button.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }

        public void LoadUserImage(int userId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT image_user FROM auth WHERE id = {userId}";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                byte[] imageData = table.Rows[0]["image_user"] as byte[];
                if (imageData != null)
                {
                    MemoryStream ms = new MemoryStream(imageData);
                    UserImage.Image = Image.FromStream(ms);
                }
            }
        }

        private void MakePictureBoxRound(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
                pictureBox.Region = new Region(path);
                g.SetClip(path);
                if (pictureBox.Image != null)
                {
                    g.DrawImage(pictureBox.Image, 0, 0, pictureBox.Width, pictureBox.Height);
                }
            }
            pictureBox.Image = bmp;
        }

        private void PensilButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                byte[] imageBytes = File.ReadAllBytes(imagePath);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    UserImage.Image = Image.FromStream(ms);
                }

                SaveImageToDatabase(imageBytes);
            }
        }

    }
}
