﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.Font = new Font("Raleway", 14, FontStyle.Bold);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            this.Hide();
            auth.ShowDialog();
        }
    }
}
