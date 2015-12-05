using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    /// <summary>
    /// Base class for synchronizing a model with a view 
    /// Passive View
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TView"></typeparam>
    public abstract class MvcControllerBase<TModel, TView> : IDisposable, IUserMessageGenerator where TView : IPassiveView
    {              
        protected TView m_view;
        protected TModel m_model;                
        protected MvcEventsController m_viewEventsController;
        
        public event EventHandler<UserMessageEventArgs> MessageRaised;

        /// <summary>
        /// Wire up action, and property change events between model and view
        /// </summary>
        protected abstract void WireEvents();

        /// <summary>
        /// Un-wire the action, and property change events between model and view
        /// </summary>
        protected abstract void UnWireEvents();

        /// <summary>
        /// Set initial view elements
        /// </summary>
        protected abstract void SetViewState();


        /// <summary>
        /// Gets the model
        /// </summary>
        public TModel Model { get { return m_model; } }


        /// <summary>
        /// Gets the view
        /// </summary>
        public TView View { get { return m_view; } }

                        
        /// <summary>
        /// Initialize the passive view controller
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        protected virtual void Initialize(TModel model,TView view)
        {            
            if(m_model != null || m_view != null)
                UnWireEvents();

            m_model = model;
            m_view = view;

            m_viewEventsController = view.EventsController;           
            WireEvents();
            SetViewState();
        }


        /// <summary>
        /// Fires user messages from action request event args
        /// Used by derived controllers
        /// </summary>
        /// <param name="args"></param>
        protected void RaiseActionMessage(ActionRequestEventArgs args)
        {
            if(args.UserMessage != null)
                MessageRaised(this, new UserMessageEventArgs(args.UserMessage));
        }

        protected void RaiseMessage(string message, UserMessageType userMessageType)
        {
            if(MessageRaised != null)
                MessageRaised(this, new UserMessageEventArgs(message, userMessageType));
        }

       /// <summary>
       /// Clean up event handlers
       /// </summary>
        public void Dispose()
        {
            UnWireEvents();
        }                
    }
}