using System;
using System.Collections.Generic;

namespace SCOUT.Core.Mvc
{
    public class ChangeRequestEvents
    {
        private Dictionary<Type, Dictionary<string, object>> m_pool;
        private object m_sender;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender"></param>
        public ChangeRequestEvents(object sender)        
        {
            m_pool = new Dictionary<Type, Dictionary<string, object>>();
            m_sender = sender;
        }

        
        /// <summary>
        /// Registers a property change listener
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="handler"></param>
        public void RegisterListener<T>(string propertyName, EventHandler<PropertyChangeRequestEventArgs<T>> handler)
        {
            Type t = typeof (T);

            if(!m_pool.ContainsKey(t))
                m_pool.Add(t, new Dictionary<string, object>());

            Dictionary<string, object> events = m_pool[t];

            if(!events.ContainsKey(propertyName))
                events.Add(propertyName, new EventHolder<T>());

            EventHolder<T> holder = events[propertyName] as EventHolder<T>;

            holder.OnEvent += handler;
        }

        /// <summary>
        /// UnRegisters a property change listener
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="handler"></param>
        public void UnRegisterListener<T>(string propertyName, EventHandler<PropertyChangeRequestEventArgs<T>> handler)
        {
            EventHolder<T> holder= GetEventHolder<T>(propertyName);

            if(holder != null)
                holder.OnEvent -= handler;
        }

        /// <summary>
        /// Fires a property changed event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="requestedValue"></param>
        public void Fire<T>(string propertyName,T requestedValue)
        {
            EventHolder<T> holder = GetEventHolder<T>(propertyName);

            if (holder != null)
                holder.Fire(m_sender, requestedValue);
        }

        private EventHolder<T> GetEventHolder<T>(string propertyName)
        {
            Type t = typeof (T);
            
            if(!m_pool.ContainsKey(t))
                return null;

            Dictionary<string, object> events = m_pool[t];

            if(!events.ContainsKey(propertyName))
                return null;

            return events[propertyName] as EventHolder<T>;
            
        }   
    }
}