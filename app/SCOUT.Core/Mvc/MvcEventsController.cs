using System;

namespace SCOUT.Core.Mvc
{

    /// <summary>
    /// Allows a mvc view to fire action requests events 
    /// and property changed events to be handled by the controller.
    /// </summary>
    public class MvcEventsController : IMvcActionEventController, IMvcPropertyChangedEventController
    {
        private ActionRequestEvents m_actionRequestEvents;
        private ChangeRequestEvents m_changeRequestEvents;        
                
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender">The view firing the events</param>
        public MvcEventsController(object sender)
        {
            m_actionRequestEvents = new ActionRequestEvents(sender);
            m_changeRequestEvents = new ChangeRequestEvents(sender);                  
        }


        #region Properties
        /// <summary>
        /// Gets the ActionRequestEvents
        /// </summary>
        public ActionRequestEvents ActionRequestEvents
        {
            get { return m_actionRequestEvents; }            
        }

        /// <summary>
        /// Gets the ChangeRequestEvents
        /// </summary>
        public ChangeRequestEvents ChangeRequestEvents
        {
            get { return m_changeRequestEvents; }
        }

 
        #endregion


        #region IMvcActionEventController implementation
        /// <summary>
        /// Registers a action/handler with the action pool
        /// </summary>
        /// <param name="action"></param>
        /// <param name="handler"></param>
        public void RegisterActionRequestHandler(string action, EventHandler<ActionRequestEventArgs> handler)
        {
            m_actionRequestEvents.RegisterAction(action, handler);
        }

        /// <summary>
        /// UnRegisters a action/handler from the action pool
        /// </summary>
        /// <param name="action"></param>
        /// <param name="handler"></param>
        public void UnRegisterActionRequestHandler(string action, EventHandler<ActionRequestEventArgs> handler)
        {
            m_actionRequestEvents.UnRegisterAction(action);
        }


        #endregion


        #region IMvcPropertyChangedViewController implementation
        /// <summary>
        /// Registers a property change/handler with the change notifcation pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="handler"></param>
        public void RegisterChangeRequestHandler<T>(string propertyName, EventHandler<PropertyChangeRequestEventArgs<T>> handler)
        {
            m_changeRequestEvents.RegisterListener(propertyName, handler);
        }


        /// <summary>
        /// UnRegisters a property change/handler from the change notification pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="handler"></param>
        public void UnRegisterChangeRequestHandler<T>(string propertyName, EventHandler<PropertyChangeRequestEventArgs<T>> handler)
        {
            m_changeRequestEvents.UnRegisterListener(propertyName, handler);
        }

        #endregion

        public void UnRegisterAllRequestHandlers()
        {
            //m_changeRequestEvents.UnRegisterAllListeners();
            //m_actionRequestEvents.UnRegisterAllListeners();            
        }
    }
}