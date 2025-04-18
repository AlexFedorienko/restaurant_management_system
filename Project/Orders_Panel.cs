using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public partial class Orders_Panel : Form
    {
        private DataBase dataBase = new DataBase();
        private Form1 form1;
        private string userName;
        private int userId;

        public Orders_Panel()
        {
            InitializeComponent();
            this.Load += Orders_Panel_Load;
        }

        public Orders_Panel(string userName, int userId) : this()
        {
            this.userName = userName;
            this.userId = userId;
        }

        private void Orders_Panel_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            dataBase.openConnection();

            string query = @"
                SELECT 
                    o.OrderId,
                    o.OrderDate,
                    o.TotalAmount,
                    a.login_user AS Customer
                FROM Orders o
                JOIN Auth a ON o.UserId = a.id";

            SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewOrder.DataSource = table;

            dataBase.closeConnection();

            CustomizeDataGridView();
        }

        private void CustomizeDataGridView()
        {
            dataGridViewOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridViewOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
            dataGridViewOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewOrder.EnableHeadersVisualStyles = false;

            dataGridViewOrder.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewOrder.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen;
            dataGridViewOrder.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewOrder.RowTemplate.Height = 40;
            dataGridViewOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrder.MultiSelect = false;

            if (!dataGridViewOrder.Columns.Contains("Complete"))
            {
                DataGridViewButtonColumn completeButton = new DataGridViewButtonColumn();
                completeButton.Name = "Complete";
                completeButton.HeaderText = "";
                completeButton.Text = "Done";
                completeButton.UseColumnTextForButtonValue = true;
                completeButton.DefaultCellStyle.BackColor = Color.LightGreen;
                dataGridViewOrder.Columns.Add(completeButton);
            }

            dataGridViewOrder.CellContentClick += dataGridViewOrder_CellContentClick;
            dataGridViewOrder.SelectionChanged += dataGridViewOrder_SelectionChanged;
        }

        private void dataGridViewOrder_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrder.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrder.SelectedRows[0].Cells["OrderId"].Value);
                LoadOrderItems(orderId);
            }
        }

        private void CustomizeDataGridViewOrderItems()
        {
            dataGridViewOrderItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridViewOrderItems.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOliveGreen;
            dataGridViewOrderItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewOrderItems.EnableHeadersVisualStyles = false;

            dataGridViewOrderItems.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewOrderItems.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewOrderItems.RowTemplate.Height = 35;
            dataGridViewOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrderItems.MultiSelect = false;
        }

        private void LoadOrderItems(int orderId)
        {
            string query = @"
                SELECT 
                    ProductName,
                    ProductPrice,
                    Quantity,
                    TotalPrice
                FROM OrderItems
                WHERE OrderId = @OrderId";

            SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@OrderId", orderId);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridViewOrderItems.DataSource = table;

            CustomizeDataGridViewOrderItems();
        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrder.Columns["Complete"].Index && e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrder.Rows[e.RowIndex].Cells["OrderId"].Value);
                var confirm = MessageBox.Show("Завершить и удалить заказ?", "Подтверждение", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    DeleteOrder(orderId);
                    LoadOrders();
                    dataGridViewOrderItems.DataSource = null;
                }
            }
        }

        private void DeleteOrder(int orderId)
        {
            string deleteItemsQuery = "DELETE FROM OrderItems WHERE OrderId = @OrderId";
            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderId = @OrderId";

            dataBase.openConnection();

            SqlCommand deleteItemsCmd = new SqlCommand(deleteItemsQuery, dataBase.getConnection());
            deleteItemsCmd.Parameters.AddWithValue("@OrderId", orderId);
            deleteItemsCmd.ExecuteNonQuery();

            SqlCommand deleteOrderCmd = new SqlCommand(deleteOrderQuery, dataBase.getConnection());
            deleteOrderCmd.Parameters.AddWithValue("@OrderId", orderId);
            deleteOrderCmd.ExecuteNonQuery();

            dataBase.closeConnection();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(userName, userId);
            admin_Panel.Show();
            this.Hide();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            form1 = new Form1(userName, userId);

            form1.Show();
            this.Close();
        }

        private void Orders_Panel_Load_1(object sender, EventArgs e)
        {

        }
    }
}
