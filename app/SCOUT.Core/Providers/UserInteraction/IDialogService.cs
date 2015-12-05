using System.Windows.Forms;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Services
{
    public interface IDialogService
    {               
        DialogResult AskQuestion(string question);
        string GetInput(string inputMessage, bool required);
        void ShowMessage(string message, UserMessageType messageType);
        void ShowMessage(string message, UserMessageType messageType, bool stubborn);
        IUserMessageOutputHost MessageOutputHost { get; }
    }
}