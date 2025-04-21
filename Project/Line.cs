using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Project
{

   
    public class Line : Control
    {
        public Color LineColor { get; set; } = Color.Blue;
        public int LineThickness { get; set; } = 2;

        public Line()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent; // Устанавливаем прозрачность
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(LineColor, LineThickness))
            {
                // Рисуем линию в нижней части элемента
                e.Graphics.DrawLine(pen, 0, Height - LineThickness / 2, Width, Height - LineThickness / 2);
            }
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Line line = new Line
            {
                Width = 200,
                Height = 10, // Задаём высоту, если нужна только линия
                LineColor = Color.Red,
                LineThickness = 2,
                Location = new Point(50, 50),
                BackColor = Color.Transparent // Убедитесь, что фон прозрачный
            };

            Controls.Add(line);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }





}
