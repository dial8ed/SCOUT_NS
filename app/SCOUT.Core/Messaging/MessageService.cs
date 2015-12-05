using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Services
{
    public abstract class MessageService : IUserMessageGenerator
    {
        private MessageListener m_listener;

        public event EventHandler<UserMessageEventArgs> MessageRaised;

        protected void RaiseUserMessage(string message, UserMessageType type)
        {
            Listener.AddProvider(this);
            MessageRaised(this, new UserMessageEventArgs(message, type));
        }

        public MessageListener Listener
        {
            get
            {
                if (m_listener == null)
                    m_listener = new MessageListener
                        (Scout.Core.UserInteraction.Dialog.MessageOutputHost, this);

                return m_listener;
            }
            set
            {
                m_listener = value;

                if(m_listener != null)
                    m_listener.AddProvider(this);
            }
        }
    }
}