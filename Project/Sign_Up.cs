using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class Regestration : Form
    {
            DataBase dbsql = new DataBase();
        public Regestration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }









        private void btnEnterSignInCreateR_Click(object sender, EventArgs e)
        {

            var login = textBoxEmaiR;
            var password = textBoxPswR;

            string querrystringsql = $"insert into auth(login_user, password_user) values('{login}', '{password}')";


            SqlCommand command = new SqlCommand(querrystringsql, dbsql.getConnection());

            dbsql.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account succesfuly created!");
                Auth frm_auth = new Auth();
                this.Hide();
                frm_auth.ShowDialog();
            }
            else
            {
                MessageBox.Show("accound wasnt created!");
            }
            dbsql.closeConnection();
        }

        private Boolean checkuser()
        { 
            var loginUser = textBoxEmaiR.Text;
            var passUser = textBoxPswR.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string querrystring = $"select id_user, login_user, password_user from auth where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querrystring, dbsql.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            if(dt.Rows.Count > 0 )
            {
                MessageBox.Show("User already added!");
                return true;

            }
            else { return false; }  
        }

        private void Regestration_Load(object sender, EventArgs e)
        {

        }




        //
        //
    }
}
