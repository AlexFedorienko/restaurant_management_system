using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project
{
    public partial class OrdersPanel : Form
    {
        private Form1 form1;
        private string userName;
        private int userId;

        public OrdersPanel()
        {
        }

        public OrdersPanel(string userName, int userId)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.userName = userName;
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form1 = new Form1(userName, userId); // Передаем данные обратно в Form1
            form1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
