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

            labelName.Text = Auth.UserName;

            MakePictureBoxRound(pictureBox1);
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
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void MakePictureBoxRound(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
            g.SetClip(path);
            g.DrawImage(pictureBox.Image, 0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
        }
    }
}
