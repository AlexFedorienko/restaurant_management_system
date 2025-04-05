using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    private int _borderRadius = 20; // Радиус закругления углов

    public int BorderRadius
    {
        get { return _borderRadius; }
        set { _borderRadius = value; this.Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Graphics graphics = pevent.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90);
            path.AddArc(this.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90);
            path.AddArc(this.Width - _borderRadius, this.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90);
            path.AddArc(0, this.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path); // Устанавливаем форму кнопки

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                graphics.FillPath(brush, path); // Задаем цвет фона
            }

            using (Pen pen = new Pen(this.FlatAppearance.BorderColor, this.FlatAppearance.BorderSize))
            {
                graphics.DrawPath(pen, path); // Рисуем рамку, если нужно
            }

            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, stringFormat);
        }
    }
}
