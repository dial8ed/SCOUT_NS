using System;
using System.Collections.Generic;

namespace SCOUT.Core.Messaging
{
    public class MessageHandler
    {
        private List<UserMessage> m_messages;

        private event Action<UserMessageEventArgs> m_messageAdded;

        public event Action<UserMessageEventArgs> MessageAdded
        {
            add { m_messageAdded += value; }
            remove { m_messageAdded -= value; }
        }

        public void AddMessage(string message, UserMessageType type)
        {        
            m_messages.Add(new UserMessage(message, type));   

            if(m_messageAdded != null)
                m_messageAdded(new UserMessageEventArgs(message, type));
        }

        public void ClearMessages()
        {
            m_messages.Clear();
        }

        public void DeleteMessage(string message)
        {
            m_messages.RemoveAll((m) => m.Message == message);
        }

        public IEnumerable<UserMessage> GetMessages()
        {
            return m_messages;
        }

    }
}