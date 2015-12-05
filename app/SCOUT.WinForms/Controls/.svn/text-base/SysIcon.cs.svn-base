using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Core.WinApi;

namespace SCOUT.WinForms.Controls
{
    /// <summary>
    /// Summary description for SysIcon.
    /// </summary>
    public class SysIcon : Control
    {
        private Icon m_icon;
        private IconIndex m_index = IconIndex.Error;

        public SysIcon()
        {
            InitIcon();
        }

        public IconIndex IconIndex
        {
            get { return m_index; }
            set
            {
                if (m_index != value)
                {
                    m_index = value;
                    InitIcon();
                }
            }
        }

        private void InitIcon()
        {
            int winval = Constant.IDI_ERROR;

            switch (m_index)
            {
                case IconIndex.Application:
                    winval = Constant.IDI_APPLICATION;
                    break;

                case IconIndex.Warning:
                    winval = Constant.IDI_WARNING;
                    break;

                case IconIndex.Error:
                    winval = Constant.IDI_ERROR;
                    break;

                case IconIndex.Information:
                    winval = Constant.IDI_INFORMATION;
                    break;

                case IconIndex.Question:
                    winval = Constant.IDI_QUESTION;
                    break;

                case IconIndex.WinLogo:
                    winval = Constant.IDI_WINLOGO;
                    break;
            }

            if (IconIndex != IconIndex.None)
                m_icon = Util.GetSystemIcon(winval);
            else
                m_icon = null;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_index != IconIndex.None)
            {
                int x = (Width - m_icon.Width) / 2;
                int y = (Height - m_icon.Height) / 2;
                Rectangle r = new Rectangle(x, y, m_icon.Width, m_icon.Height);

                e.Graphics.DrawIconUnstretched(m_icon, r);
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

    }

    public enum IconIndex
    {
        None = 0,
        Application,
        Warning,
        Error,
        Information,
        Question,
        WinLogo
    };
}