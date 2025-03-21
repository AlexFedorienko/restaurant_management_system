using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class Regestration : Form
    {
        DataBase dbsql = new DataBase();
        Auth frm_auth = new Auth();

        public Regestration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnEnterSignInCreateR_Click(object sender, EventArgs e)
        {
            var login = textBoxLoginR.Text;
            var email = textBoxUserEmailR.Text;
            var password = textBoxPswR.Text;
            var confirmPassword = textBoxConfirmPswR.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (checkuser(login))
            {
                MessageBox.Show("User already exists!");
                return;
            }

            string querystring = $"INSERT INTO Auth (login_user, password_user, email_user) " +
                                 $"VALUES ('{login}', '{password}', '{email}')";

            SqlCommand command = new SqlCommand(querystring, dbsql.getConnection());
            dbsql.openConnection();

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created!");
                    this.Close();
                    frm_auth.Show();
                }
                else
                {
                    MessageBox.Show("Account was not created!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                dbsql.closeConnection();
            }
        }

        private Boolean checkuser(string loginUser)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string querystring = $"SELECT login_user FROM Auth WHERE login_user = '{loginUser}'";

            SqlCommand command = new SqlCommand(querystring, dbsql.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);

            return dt.Rows.Count > 0;
        }

        private void SignInRButton_Click(object sender, EventArgs e)
        {
            frm_auth.Show();
            this.Close();
        }
    }
}