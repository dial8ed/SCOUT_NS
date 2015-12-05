using System.Windows.Forms;
using SCOUT.Core.Messaging;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// A output host that displays a message in a MessageBox
    /// </summary>
    public class MessageBoxOutputHost : IUserMessageOutputHost
    {
        public void ProcessMessage(UserMessageEventArgs args)
        {
            ShowMessageBox(args.UserMessage);
        }

        private void ShowMessageBox(UserMessage message)
        {
            MessageBox.Show(message.Message,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            GetIcon(message));           
        }

        /// <summary>
        /// Gets the appropriate message box icon for the user message type
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private MessageBoxIcon GetIcon(UserMessage message)
        {
            switch(message.MessageType)
            {
                case UserMessageType.Error:
                    return MessageBoxIcon.Error;
                case UserMessageType.Information:
                    return MessageBoxIcon.Information;
                case UserMessageType.Validation:
                    return MessageBoxIcon.Stop;
                case UserMessageType.Warning:
                    return MessageBoxIcon.Warning;
            }

            return MessageBoxIcon.None;            
        }
    }
}