using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SCOUT.WinForms
{
    public partial class SuperConfirmForm : Form
    {
        private string m_fieldName;

        public SuperConfirmForm(string fieldName)
        {
            InitializeComponent();

            m_fieldName = fieldName;
            msgLabel.Text = String.Format(msgLabel.Text, m_fieldName);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            string txt = confTxt.Text.ToLower().Trim();

            if (txt != "yes")
                DialogResult = DialogResult.Cancel;
            else
                DialogResult = DialogResult.OK;
        }
    }
}