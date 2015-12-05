using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Inventory.UI
{
    public partial class StubbornMessageBox : Form
    {
        private MessageBoxButtons m_buttons;
        private DialogResult m_result;

        public StubbornMessageBox(string message, MessageBoxButtons buttons)
        {
            InitializeComponent();
            messageText.Text = message;
            m_buttons = buttons;

            SetupButtons();
            WireEvents();
        }

        private void WireEvents()
        {
            okButton.Click += button_Click;
            yesButton.Click += button_Click;
            noButton.Click += button_Click;
        }

        private void button_Click(object sender, EventArgs e)
        {
            SetResult((SimpleButton) sender);
            Close();
        }

        private void SetResult(SimpleButton button)
        {
            switch (button.Name)
            {
                case "okButton":
                    {
                        m_result = DialogResult.OK;
                        return;
                    }

                case "yesButton":
                    {
                        m_result = DialogResult.Yes;
                        return;
                    }
                case "noButton":
                    {
                        m_result = DialogResult.No;
                        return;
                    }
            }
        }

        private void SetupButtons()
        {
            okButton.Visible = m_buttons.Equals(MessageBoxButtons.OK);
            yesButton.Visible = m_buttons.Equals(MessageBoxButtons.YesNo);
            noButton.Visible = m_buttons.Equals(MessageBoxButtons.YesNo);
        }

        public DialogResult ShowMessage
        {
            get { return m_result; }
        }
    }
}