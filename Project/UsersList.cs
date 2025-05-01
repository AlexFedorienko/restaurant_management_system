using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public partial class UsersList : Form
    {
        private DataBase dataBase = new DataBase();
        private Form1 form1;
        private string userName;
        private int userId;

        public UsersList()
        {
            InitializeComponent();
            this.Load += UsersList_Load;
        }

        public UsersList(string userName, int userId) : this()
        {
            this.userName = userName;
            this.userId = userId;
        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            dataBase.openConnection();

            string query = @"
                SELECT 
                    id AS UserId,
                    login_user AS UserName,
                    email_user AS Email,
                    IsTrue
                FROM Auth";

            SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewUsersList.DataSource = table;

            AddAdminButton();
            CustomizeGrid();

            dataBase.closeConnection();
        }

        private void AddAdminButton()
        {
            if (!dataGridViewUsersList.Columns.Contains("MakeAdmin"))
            {
                DataGridViewButtonColumn makeAdminButton = new DataGridViewButtonColumn();
                makeAdminButton.Name = "MakeAdmin";
                makeAdminButton.HeaderText = "";
                makeAdminButton.Text = "Make Admin";
                makeAdminButton.UseColumnTextForButtonValue = true;
                makeAdminButton.DefaultCellStyle.BackColor = Color.LightGreen;
                dataGridViewUsersList.Columns.Add(makeAdminButton);
            }

            dataGridViewUsersList.CellContentClick += dataGridViewUsersList_CellContentClick;
        }

        private void dataGridViewUsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewUsersList.Columns["MakeAdmin"].Index && e.RowIndex >= 0)
            {
                int isAdmin = Convert.ToInt32(dataGridViewUsersList.Rows[e.RowIndex].Cells["IsTrue"].Value);

                if (isAdmin == 0)
                {
                    int selectedUserId = Convert.ToInt32(dataGridViewUsersList.Rows[e.RowIndex].Cells["UserId"].Value);

                    var confirm = MessageBox.Show("Confirm making this user admin?", "Confirming", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        MakeAdmin(selectedUserId);
                        LoadUsers(); 
                    }
                }
            }
        }

        private void MakeAdmin(int userId)
        {
            string query = "UPDATE Auth SET IsTrue = 1 WHERE id = @UserId";

            SqlCommand cmd = new SqlCommand(query, dataBase.getConnection());
            cmd.Parameters.AddWithValue("@UserId", userId);

            dataBase.openConnection();
            cmd.ExecuteNonQuery();
            dataBase.closeConnection();
        }

        private void CustomizeGrid()
        {
            dataGridViewUsersList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridViewUsersList.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dataGridViewUsersList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUsersList.EnableHeadersVisualStyles = false;

            dataGridViewUsersList.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewUsersList.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen;
            dataGridViewUsersList.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewUsersList.RowTemplate.Height = 35;
            dataGridViewUsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsersList.MultiSelect = false;
        }

        private void buttonDashBoardAP_Click(object sender, EventArgs e)
        {
            Admin_Panel adminPanel = new Admin_Panel(userName, userId);
            adminPanel.Show();
            this.Hide();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            form1 = new Form1(userName, userId);
            form1.Show();
            this.Close();
        }
    }
}
