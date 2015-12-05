using System.Windows.Forms;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Providers
{
    public class DialogService : IDialogService
    {
        private IUserMessageOutputHost m_messageOutput;

        public DialogService(IUserMessageOutputHost messageOutputHost)
        {
            m_messageOutput = messageOutputHost;
        }

        public DialogService()
        {
            m_messageOutput = new MessageBoxOutputHost();
        }
   
        public DialogResult AskQuestion(string question)
        {
            return MessageBox.Show(question, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public string GetInput(string inputMessage, bool required)
        {                    
            IOutputCommand<string> command = 
                FrontController.GetInstance().RunCommand
                ("input.userinput", inputMessage, required) as IOutputCommand<string>;

            return command.Output;
        }

        public void ShowMessage(string message, UserMessageType messageType)
        {
            m_messageOutput.ProcessMessage
                (new UserMessageEventArgs(message, messageType));
        }

        public void ShowMessage(string message, UserMessageType messageType, bool stubborn)
        {
            IUserMessageOutputHost messageHost = new StubbornMessageBoxOutputHost();
            messageHost.ProcessMessage(new UserMessageEventArgs(message, messageType));            
        }


        public IUserMessageOutputHost MessageOutputHost
        {
            get { return m_messageOutput; }
        }
    }
}