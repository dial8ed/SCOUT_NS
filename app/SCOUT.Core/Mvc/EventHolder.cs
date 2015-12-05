using System;

namespace SCOUT.Core.Mvc
{
    public class EventHolder<T>
    {
        private event EventHandler<PropertyChangeRequestEventArgs<T>> m_onEvent;

        public void Fire(object sender, T requestedValue)
        {
            if(null != m_onEvent)
                m_onEvent(sender, new PropertyChangeRequestEventArgs<T>(requestedValue));
        }
     
        public event EventHandler<PropertyChangeRequestEventArgs<T>> OnEvent
        {
            add { m_onEvent += value; }
            remove { m_onEvent -= value; }
        }

    }
}