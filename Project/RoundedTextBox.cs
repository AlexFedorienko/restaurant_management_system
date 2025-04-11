using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : TextBox
{
    private int _borderRadius = 30; // Радиус закругления углов

    public int BorderRadius
    {
        get { return _borderRadius; }
        set { _borderRadius = value; this.Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90);
            path.AddArc(this.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90);
            path.AddArc(this.Width - _borderRadius, this.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90);
            path.AddArc(0, this.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path); // Применение закруглений
        }
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        this.SetStyle(ControlStyles.UserPaint, true); // Включение пользовательской отрисовки
    }



    public RoundedTextBox()
    {
        this.ForeColor = Color.Black; // Устанавливаем фиксированный цвет текста
        this.BorderStyle = BorderStyle.FixedSingle; // Убираем возможные стили границы
        this.Padding = new Padding(8); // Задаём отступы внутри текстового поля
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        // Здесь можно добавить логику для обработки изменений текста
    }
}



