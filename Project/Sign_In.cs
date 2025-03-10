using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project
{
    public partial class Auth : Form
    {
        DataBase database = new DataBase();
        Form1 frm1 = new Form1();
        Admin_Panel admin_Panel = new Admin_Panel();

        public static string UserName { get; private set; }

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

            string querystring = $"select login_user, password_user from auth where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count >= 1)
            {
                UserName = table.Rows[0]["login_user"].ToString();

                this.Close();
                admin_Panel.Show();
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
        }
    }
}