using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Mvc
{
    public abstract class ViewControllerBase<TModel, TView> : 
        MvcControllerBase<TModel, TView> 
        where TModel : IPersistentModel where TView : IPassiveView
    {
        private MessageListener m_messageListener;
        protected ActionService m_actionService;

        protected event EventHandler<EventArgs> TaskCompleted;
        protected event EventHandler<EventArgs> TaskCancelled;
        
 
        /// <summary>
        /// Gets the action service for running actions
        /// </summary>
        public ActionService ActionService
        {
            get { return m_actionService; }
        }

        protected MessageListener MessageListener
        {
            get { return m_messageListener; }            
        }


        protected override void Initialize(TModel model, TView view)
        {
            base.Initialize(model, view);            
            m_actionService = new ActionService();

            InitializeMessaging();
        }

       
        protected void RaiseTaskCompleted()
        {
            if (TaskCompleted != null)
                TaskCompleted(this, new EventArgs());
        }

        /// <summary>
        /// Initialize messaging elements
        /// </summary>
        private void InitializeMessaging()
        {
            m_messageListener = new MessageListener(View.UserMessageOutputHost);
            m_messageListener.AddProvider(this);
            m_messageListener.AddProvider(m_actionService);
        }
    }
}