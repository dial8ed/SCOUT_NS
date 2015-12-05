using System;

namespace SCOUT.Core.Messaging
{
    /// <summary>
    /// A message listener that outputs messages to the console window.
    /// </summary>
    public class ConsoleOutputHost : IUserMessageOutputHost
    {
        public void ProcessMessage(UserMessageEventArgs message)
        {
            Console.WriteLine(message.Message);
        }
    }
}