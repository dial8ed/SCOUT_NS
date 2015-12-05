using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCOUT.WinForms.Core
{
    public partial class CommandInputForm : DevExpress.XtraEditors.XtraForm
    {
        private FrontController m_controller = FrontController.GetInstance();

        public CommandInputForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            commandText.Validated += commandText_Validated;
        }

        void commandText_Validated(object sender, EventArgs e)
        {
            if (commandText.Text.Length > 0)
            {
                m_controller
                    .RunCommand(commandText.Text); 
               Close();
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            commandText_Validated(null, null);
        }
    }
}