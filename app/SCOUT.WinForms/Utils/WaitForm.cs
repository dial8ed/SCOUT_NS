using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SCOUT.WinForms
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return msgLabel.Text; }
            set { msgLabel.Text = value; }
        }

        public void Dismiss()
        {
            DialogResult = DialogResult.OK;
        }
    }
}