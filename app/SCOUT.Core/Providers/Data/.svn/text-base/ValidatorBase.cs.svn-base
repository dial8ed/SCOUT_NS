using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Supertype for Validators
    /// </summary>
    public abstract class ValidatorBase : IValidator, IUserMessageGenerator
    {
        protected string m_error = "";
        protected MessageListener m_listener = null;
        protected bool m_suppressMessages = false;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listener">The callback listener that will display an error if it exists.</param>
        protected ValidatorBase(MessageListener listener)
        {
            if(listener == null)
                return;

            m_listener = listener;
            m_listener.AddProvider(this);
        }

        protected ValidatorBase()
        {
            
        }

        #region IUserMessageProvider Members

        public event EventHandler<UserMessageEventArgs> MessageRaised;

        #endregion

        #region IValidator Members


        public bool HasError()
        {
            return !string.IsNullOrEmpty(m_error);            
        }

        public string Error
        {
            get { return m_error; }
            set { m_error = value;}
        }

        public abstract void GetError();
        
        public void ShowError()
        {
            Scout.Core.UserInteraction.Dialog.ShowMessage(m_error, UserMessageType.Error);            
        }

        public void RaiseError()
        {
            // If there are error messages let any listeners know.
            UserMessage message;
            message = new UserMessage(m_error, UserMessageType.Validation);
            if (MessageRaised != null)
            {
                MessageRaised(this, new UserMessageEventArgs(message));
            }
        }

        public bool Validated()
        {
            // Validated the object
            GetError();

            // If there is an error then show the error
            if (HasError())
            {
                Console.Beep();

                if (m_listener != null)
                    RaiseError();
                else
                    ShowError();

                return false;
            }

            return true;
        }
  
        #endregion

        public bool SuppressMessages
        {
            get { return m_suppressMessages; }
            set { m_suppressMessages = value;}
        }

        public MessageListener MessageListener
        {
            get { return m_listener; }
            set
            {
                if (m_listener != null)
                    m_listener.ClearProviders();

                m_listener = value;                
                m_listener.AddProvider(this);                
            }
        }
    }
}