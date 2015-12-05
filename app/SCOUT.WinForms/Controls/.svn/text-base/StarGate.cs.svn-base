using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace SCOUT.WinForms.Controls
{
    /// <summary>
    /// Summary description for SpinProgress.
    /// </summary>
    public class StarGate : System.Windows.Forms.Control
    {
        private Timer m_timer;
        private int m_value = 0;

        private int m_segments = 18;

        private int m_centerRadius = 70;
        private int m_borderSize = 2;

        public StarGate()
        {
            ForeColor = SystemColors.ActiveCaption;

            base.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, 
                true);

            base.SetStyle(ControlStyles.Opaque, false);

            m_timer = new Timer();
            m_timer.Interval = 50;
            m_timer.Tick += new EventHandler(m_timer_Tick);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                m_timer.Dispose();

            base.Dispose(disposing);
        }

        [DefaultValue(false)]
        public bool IsSpinning
        {
            get { return m_timer.Enabled; }
            set { m_timer.Enabled = value; }
        }

        [DefaultValue(18)]
        public int Segments
        {
            get { return m_segments; }
            set
            {
                value = Math.Max(8, Math.Min(36, value));

                if (m_segments != value)
                {
                    m_segments = value;

                    while (m_value >= m_segments)
                        m_value -= m_segments;

                    Invalidate();
                }
            }
        }

        [DefaultValue(70)]
        public int CenterRadius
        {
            get { return m_centerRadius; }
            set
            {
                value = Math.Max(0, Math.Min(99, value));

                if (m_centerRadius != value)
                {
                    m_centerRadius = value;
                    Invalidate();
                }
            }
        }

        [DefaultValue(2)]
        public int BorderSize
        {
            get { return m_borderSize; }
            set
            {
                value = Math.Max(0, Math.Min(8, value));

                if (m_borderSize != value)
                {
                    m_borderSize = value;
                    Invalidate();
                }
            }
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            if (Enabled)
            {
                if (++m_value >= m_segments)
                    m_value = 0;

                Invalidate();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do nothing
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush inactB = new SolidBrush(ForeColor);
            Brush actB1 = 
                new SolidBrush(ControlPaint.LightLight(ForeColor));
            Brush actB2 =
                new SolidBrush(ControlPaint.Light(ForeColor));
            Brush bg = new SolidBrush(BackColor);
            float segSz = 360.0f / m_segments;
            int oneOff = m_value - 1;
            float wth, hgt;

            wth = Width - 1.0f;
            hgt = Height - 1.0f;

            if (oneOff < 0)
                oneOff += m_segments;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillRectangle(bg, 0, 0, Width, Height);

            for (int i = 0; i < m_segments; ++i)
            {
                Brush b;
                
                if (Enabled)
                {
                    if (i == m_value)
                        b = actB1;
                    else if (i == oneOff)
                        b = actB2;
                    else
                        b = inactB;
                }
                else
                    b = SystemBrushes.InactiveCaption;

                g.FillPie(b, 0, 0, wth, hgt, 
                          (i * segSz) + (m_borderSize / 2.0f), 
                          (segSz - m_borderSize));
            }

            if (m_centerRadius > 0)
            {
                float w = wth / 2.0f;
                float h = hgt / 2.0f;
                float wr = (int)(wth / 100.0 * m_centerRadius);
                float hr = (int)(hgt / 100.0 * m_centerRadius);

                g.FillEllipse(bg, w - (wr / 2), h - (hr / 2), 
                              wr, hr);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

    }
}