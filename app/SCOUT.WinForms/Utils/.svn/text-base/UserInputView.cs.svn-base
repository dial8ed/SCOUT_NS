using System;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Messaging;

namespace SCOUT.WinForms
{       
    public partial class UserInputView : Form
    {
        private Action<string> m_callBack;
        private bool m_required;

        public UserInputView(Action<string> callBack, string inputMessage, bool required)
        {
            InitializeComponent();
            m_callBack = callBack;
            inputMessageLabel.Text = inputMessage;
            m_required = required;

            WireEvents();
        }

        private void WireEvents()
        {
            okButton.Click += okButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        void okButton_Click(object sender, EventArgs e)
        {
            if(IsValidInput())
            {
                m_callBack(memoEdit1.Text);
                DialogResult = DialogResult.OK;                
            }                        
        }

        public bool ShowCancelButton
        {
            set
            {                                
                cancelContainer.Visibility = value ? LayoutVisibility.Always : LayoutVisibility.Never;                                                                                   
            }
        }

        private bool IsValidInput()
        {
            if(m_required && string.IsNullOrEmpty(memoEdit1.Text))
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage
                    ("Input is required.", UserMessageType.Validation);

                return false;
            }
            return true;
        }

    }
}
