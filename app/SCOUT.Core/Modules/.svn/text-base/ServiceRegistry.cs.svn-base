using System;
using System.Collections.Generic;

namespace SCOUT.Core.Services
{
    public class ServiceRegistry
    {        
        private Dictionary<Type, object> m_registry;

        public ServiceRegistry()
        {
            m_registry = new Dictionary<Type, object>();
        }

         public T Get<T>() where T: class
        {
             return Contains<T>();           
        }

        public void Register<T>(T service)
        {
            if(m_registry.ContainsKey(typeof(T)))
                Remove<T>();

            m_registry.Add(typeof(T), service);            
        }

        public void Remove<T>()
        {
            m_registry.Remove(typeof(T));
        }

        private T Contains<T>() where T: class
        {
            if (m_registry.ContainsKey(typeof(T)))
                return (T)m_registry[typeof (T)];

            return null;            
        }
        
        public Dictionary<Type,object> Registry
        {
            get { return m_registry; }
        }       
    }
}