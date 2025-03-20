using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class Auth : Form
    {
        DataBase database = new DataBase();
        Form1 form1;

        public static string UserName { get; private set; }
        public static int UserId { get; private set; }

        public Auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnEnterSignIn_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_Login.Text;
            var passUser = textBox_Psw.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id, login_user, password_user from auth where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count >= 1)
            {
                UserName = table.Rows[0]["login_user"].ToString();
                UserId = Convert.ToInt32(table.Rows[0]["id"]);
                form1 = new Form1(UserName, UserId);
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login or password is incorrect");
            }
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

        private void btnEnterMainForm_Click(object sender, EventArgs e)
        {
            string defaultUserName = "Guest"; 
            int defaultUserId = 0;

            form1 = new Form1(defaultUserName, defaultUserId);

            form1.Show();
            this.Hide();
        }
    }
}