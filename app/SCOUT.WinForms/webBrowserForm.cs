using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCOUT.WinForms
{
    public partial class WebBrowserForm : DevExpress.XtraEditors.XtraForm
    {
        public WebBrowserForm(string url)
        {
            InitializeComponent();
            webBrowser.Url = new Uri(@url);
        }
    }
}