using System;

namespace SCOUT.Core.Messaging
{
    public class BlackHoleOutputHost : IUserMessageOutputHost
    {
        public void ProcessMessage(UserMessageEventArgs message)
        {
            // Do Nothing.
        }
    }
}