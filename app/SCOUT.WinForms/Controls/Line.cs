using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace SCOUT.WinForms.Controls
{
    public enum LineDrawStyle
    {
        System = 0,
        Flat,
        XP,
        Etched
    }

    public abstract class Line : Control
    {
        public Line()
        {
            base.TabStop = false;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, 
                true);

            SetStyle(
                ControlStyles.ContainerControl |
                ControlStyles.Opaque, false);
        }

        private LineDrawStyle m_drawStyle = LineDrawStyle.System;

        [
            Bindable(true),
            Browsable(true),
            Category("Appearance"),
            Description("Gets or sets the current drawing style of the line.")
        ]
        public LineDrawStyle LineDrawStyle
        {
            get { return m_drawStyle; }
            set
            {
                if (m_drawStyle != value)
                {
                    m_drawStyle = value;
                    Invalidate();
                }
            }
        }

        [
            Bindable(false),
            Browsable(false),
        ]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }

        protected abstract void DrawClassicLine(Graphics g);
        protected abstract void DrawFlatLine(Graphics g, Color c);

        protected override void OnPaint(PaintEventArgs e)
        {
            if (BackColor != Color.Transparent)
            {
                Brush b = new SolidBrush(BackColor);
                e.Graphics.FillRectangle(b, ClientRectangle);
            }

            switch (LineDrawStyle)
            {
                case LineDrawStyle.System:
                    if (Application.RenderWithVisualStyles)
                        DrawFlatLine(e.Graphics, ControlPaint.Light(ForeColor));
                    else
                        DrawClassicLine(e.Graphics);
                    break;
                
                case LineDrawStyle.Flat:
                    DrawFlatLine(e.Graphics, ForeColor);
                    break;

                case LineDrawStyle.XP:
                    DrawFlatLine(e.Graphics, ControlPaint.Light(ForeColor));
                    break;

                case LineDrawStyle.Etched:
                    DrawClassicLine(e.Graphics);
                    break;
            }
           
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
    }

    /// <summary>
    /// Summary description for Line.
    /// </summary>
    public class HLine : Line
    {
        protected override void DrawClassicLine(Graphics g)
        {
            int y = Height / 2;

            g.DrawLine(SystemPens.ControlDarkDark,
                       0, y, Width, y);

            g.DrawLine(SystemPens.ControlLightLight,
                       0, y + 1, Width, y + 1);
        }

        protected override void DrawFlatLine(Graphics g, Color c)
        {
            int y = Height / 2;
            Pen p = new Pen(c);

            g.DrawLine(p, 0, y, Width, y);
        }
    }

    public class VLine : Line
    {
        protected override void DrawClassicLine(Graphics g)
        {
            int x = Width / 2;

            g.DrawLine(SystemPens.ControlDarkDark,
                       x, 0, x, Height);

            g.DrawLine(SystemPens.ControlLightLight,
                       x + 1, 0, x + 1, Height);
        }

        protected override void DrawFlatLine(Graphics g, Color c)
        {
            int x = Width / 2;

            Pen p = new Pen(c);

            g.DrawLine(p, x, 0, x, Height);
        }
    }
}