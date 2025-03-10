using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            int radius = 70;
            panel1.Region = new Region(CreateRoundRectangle(panel1.ClientRectangle, radius));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            this.Hide();
            auth.ShowDialog();
        }

        private static GraphicsPath CreateRoundRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddLine(rect.Left, rect.Top, rect.Left, rect.Top);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddLine(rect.Right - radius, rect.Bottom, rect.Left, rect.Bottom);
            path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top);
            path.CloseFigure();
            return path;
        }
    }
}
