using System.Collections.Generic;

namespace SCOUT.Core.Messaging
{

    /// <summary>
    /// Simple class to encapsulate a user message
    /// </summary>
    public class UserMessage
    {
        private string m_message;
        private UserMessageType m_messageType;

        public UserMessage(string message, UserMessageType messageType)
        {
            m_message = message;
            m_messageType = messageType;
        }

        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        public UserMessageType MessageType
        {
            get { return m_messageType; }
            set { m_messageType = value; }
        }

        public override string ToString()
        {
            return Message;
        }
    }
}