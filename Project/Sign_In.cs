using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Mail;

namespace Project
{
    public partial class Auth : Form
    {
        DataBase database = new DataBase();
        Form1 form1;
        public static bool IsAdmin { get; private set; }
        public static string UserName { get; private set; }
        public static int UserId { get; private set; }

        private readonly string rememberMeFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FoodDelivery_AuthRemember.dat");

        public Auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            CheckRememberedUser();
        }

        private void CheckRememberedUser()
        {
            if (File.Exists(rememberMeFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(rememberMeFilePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        var data = (RememberMeData)formatter.Deserialize(fs);
                        textBox_Login.Text = data.Login;
                        textBox_Psw.Text = data.Password;
                        guna2ToggleSwitch1.Checked = true;
                    }
                }
                catch { }
            }
        }

        private void btnEnterSignIn_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_Login.Text;
            var passUser = textBox_Psw.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id, login_user, password_user, IsTrue from Auth where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count >= 1)
            {
                UserName = table.Rows[0]["login_user"].ToString();
                UserId = Convert.ToInt32(table.Rows[0]["id"]);
                IsAdmin = Convert.ToBoolean(table.Rows[0]["IsTrue"]);

                if (guna2ToggleSwitch1.Checked)
                {
                    SaveRememberMeData(loginUser, passUser);
                }
                else
                {
                    ClearRememberMeData();
                }

                form1 = new Form1(UserName, UserId);
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login or password is incorrect");
            }
        }

        private void SaveRememberMeData(string login, string password)
        {
            try
            {
                using (FileStream fs = new FileStream(rememberMeFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, new RememberMeData { Login = login, Password = password });
                }
            }
            catch { }
        }

        private void ClearRememberMeData()
        {
            if (File.Exists(rememberMeFilePath))
            {
                try
                {
                    File.Delete(rememberMeFilePath);
                }
                catch { }
            }
        }

        [Serializable]
        private class RememberMeData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            Regestration regestration = new Regestration();
            regestration.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SendPasswordByEmail(string toEmail, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("fooddeliverysbna@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Your Password";
                mail.Body = $"Hello,\n\nYou requested your password.\n\nYour password is: {password}\n\nBest regards,\nFood Delivery App Team";

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("fooddeliverysbna@gmail.com", "kyxj fylc ggwo zhiq"); // Gmail App Password
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Password has been sent to your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send the email: " + ex.Message);
            }
        }

        private void sendPasswordToEmail_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_Login.Text;

            if (string.IsNullOrEmpty(loginUser))
            {
                MessageBox.Show("Please enter your login.");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"SELECT password_user, email_user FROM Auth WHERE login_user = '{loginUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                string password = table.Rows[0]["password_user"].ToString();
                string email = table.Rows[0]["email_user"].ToString();

                SendPasswordByEmail(email, password);
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void btnEnterMainForm_Click(object sender, EventArgs e)
        {
            string defaultUserName = "Guest";
            int defaultUserId = 0;
            form1 = new Form1(defaultUserName, defaultUserId);
            form1.Show();
            this.Hide();
        }

        // Остальные события
        private void gradientPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void materialSwitch1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox_Login_TextChanged(object sender, EventArgs e) { }
        private void gradientPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void roundedTextBox1_TextChanged(object sender, EventArgs e) { }
        private void loginTextBox_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void line1_Click(object sender, EventArgs e) { }
    }
}