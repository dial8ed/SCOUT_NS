using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCOUT.WinForms.Security
{
    public partial class DirtyPasswordDialog : DevExpress.XtraEditors.XtraForm
    {
        public DirtyPasswordDialog()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(passwordText.Text == "blackmags")
            {
                DialogResult = DialogResult.Yes;
            } else
            {
                MessageBox.Show("Invalid password", Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}