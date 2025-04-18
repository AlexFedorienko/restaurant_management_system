using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedRichTextBox : RichTextBox
{
    private int _cornerRadius = 20;

    public int CornerRadius
    {
        get => _cornerRadius;
        set
        {
            _cornerRadius = value;
            this.Invalidate(); // Обновляем компонент
        }
    }

    public void ApplyRoundedCorners()
    {
        if (!this.IsHandleCreated)
            return; // Убеждаемся, что дескриптор окна создан

        using (GraphicsPath path = CreateRoundedRectanglePath(this.ClientRectangle, _cornerRadius))
        {
            this.Region = new Region(path); // Применяем скругление через Region
        }
    }

    private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;

        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ApplyRoundedCorners(); // Применяем скругление после создания Handle
    }
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();

            RoundedRichTextBox roundedRichTextBox = new RoundedRichTextBox
            {
                CornerRadius = 30,
                BackColor = Color.White,
                Size = new Size(300, 150),
                Location = new Point(20, 20)
            };

            this.Controls.Add(roundedRichTextBox);
            roundedRichTextBox.ApplyRoundedCorners(); // Применяем скругление
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }



};


 

