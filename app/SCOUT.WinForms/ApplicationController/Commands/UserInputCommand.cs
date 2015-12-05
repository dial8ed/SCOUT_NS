using System;
using System.Windows.Forms;

namespace SCOUT.WinForms.Core
{
    public class UserInputCommand : Command, IOutputCommand<string>
    {
        private string m_output;
        private bool m_required;
        private string m_inputMessage;

        public UserInputCommand(params object[] input) : base(input)
        {
            m_inputMessage = input[0].ToString();
            bool.TryParse(input[1].ToString(), out m_required);
        }

        public override void Execute()
        {            
            UserInputView view = 
                new UserInputView(InputCallBack, m_inputMessage, m_required);

            view.StartPosition = FormStartPosition.CenterParent;
            view.ShowDialog();
        }

        public void InputCallBack(string input)
        {
            m_output = input;
        }

        public string Output
        {
            get { return m_output; }
        }
    }
}