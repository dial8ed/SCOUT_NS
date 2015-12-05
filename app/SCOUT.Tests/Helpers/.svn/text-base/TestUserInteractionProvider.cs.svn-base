using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Tests.Helpers
{
    public class TestUserInteractionProvider : IUserInteractionProvider
    {
        private IPrintingService m_printing;
        private IDialogService m_dialog;

        public TestUserInteractionProvider()
        {
            m_printing = new PrintingService();
            m_dialog = new DialogService();          
        }

        public IPrintingService Printing
        {
            get { return m_printing; }
        }

        public IDialogService Dialog
        {
            get { return m_dialog; }
        }

        public IViewService Views
        {
            get { throw new NotImplementedException(); }
        }

        private class PrintingService : IPrintingService
        {
            public bool PrintZplLabel(ZPLLabel label)
            {
                return true;
            }
        }

        private class DialogService : IDialogService
        {
            public DialogResult AskQuestion(string question)
            {
                throw new NotImplementedException();
            }

            public string GetInput(string inputMessage, bool required)
            {
                throw new NotImplementedException();
            }

            public void ShowMessage(string message, UserMessageType messageType)
            {
                Console.WriteLine(message + " " + messageType);
            }

            public void ShowMessage(string message, UserMessageType messageType, bool stubborn)
            {
                ShowMessage(message, messageType);
            }

            public IUserMessageOutputHost MessageOutputHost
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}