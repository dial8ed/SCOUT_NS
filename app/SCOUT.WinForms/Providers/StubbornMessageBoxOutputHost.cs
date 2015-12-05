using System;
using System.Windows.Forms;
using Inventory.UI;
using SCOUT.Core.Messaging;

namespace SCOUT.WinForms.Providers
{
    public class StubbornMessageBoxOutputHost : IUserMessageOutputHost
    {
        public void ProcessMessage(UserMessageEventArgs message)
        {
            StubbornMessageBox messageBox =
                new StubbornMessageBox(message.Message, MessageBoxButtons.OK);

            messageBox.ShowDialog();
        }
    }
}