using System;
using System.Collections.Generic;

namespace SCOUT.Core.Mvc
{
    public class ActionRequestEvents
    {
        private Dictionary<string, EventHandler<ActionRequestEventArgs>> m_pool;
        private object m_sender;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender"></param>
        public ActionRequestEvents(object sender) : this()
        {
            m_sender = sender;
        }

        public ActionRequestEvents()
        {
            m_pool = new Dictionary<string, EventHandler<ActionRequestEventArgs>>();
        }

        /// <summary>
        /// Registers a action handler
        /// </summary>
        /// <param name="action"></param>
        /// <param name="handler"></param>
        public void RegisterAction(string action, EventHandler<ActionRequestEventArgs> handler)
        {
            if(!m_pool.ContainsKey(action))
                m_pool.Add(action, handler);                                  
        }

        /// <summary>
        /// UnRegisters a action handler
        /// </summary>
        /// <param name="action"></param>
        public void UnRegisterAction(string action)
        {
            if (m_pool.ContainsKey(action))
                m_pool.Remove(action);
        }


        /// <summary>
        /// Returns a string arrary of registered action handlers
        /// </summary>
        public string[] Actions
        {
            get
            {
                string[] actions = 
                    new string[m_pool.Keys.Count];

                m_pool.Keys.CopyTo(actions, 0);

                return actions;
            }
        }


        /// <summary>
        /// Fires a action request event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="action"></param>
        public void Fire(object sender, string action)
        {
            if(!m_pool.ContainsKey(action))
                throw new ArgumentOutOfRangeException(action + " is not a registered action for this view."); 

            EventHandler<ActionRequestEventArgs> handler = m_pool[action];
            if(handler != null)
                handler(m_sender, new ActionRequestEventArgs());
        }
    }
}