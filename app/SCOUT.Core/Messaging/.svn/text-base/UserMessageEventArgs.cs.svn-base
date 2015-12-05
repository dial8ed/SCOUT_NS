using System;
using System.Collections.Generic;

namespace SCOUT.Core.Messaging
{
    /// <summary>
    /// Event Argument that encapsulates a UserMessage.
    /// </summary>
    public class UserMessageEventArgs : EventArgs
    {
        private UserMessage m_message;

        public UserMessageEventArgs(UserMessage message)
        {
            m_message = message;
        }

        public UserMessageEventArgs(string message,UserMessageType type) 
            : this(new UserMessage(message,type))
        {
                          
        }

        public UserMessage UserMessage
        {
            get { return m_message; }
        }

        public string Message
        {
            get { return m_message.Message; }
        }

        /// <summary>
        /// The type of user message
        /// </summary>
        public UserMessageType Type
        {
            get { return m_message.MessageType; }
        }
    }
}