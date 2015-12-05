using System;
using System.Collections.Generic;

namespace SCOUT.Core.Bus
{
    public  class EventBus : IEventBus
    {
        private List<Delegate> m_handlers;

        public void Register<T>(Action<T> handler)
        {
            if (m_handlers == null)
                m_handlers = new List<Delegate>();

            m_handlers.Add(handler);

        }

        public void Raise<T>(T message)
        {
            if(m_handlers != null)
                foreach (var handler in m_handlers)
                {
                    if (handler is Action<T>)
                        ((Action<T>) handler)(message);
                }
        }
    }
}