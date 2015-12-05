using System;
using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.Core.Modules
{
     public abstract class ModuleBase : IModule
    {
        private ServiceRegistry m_serviceRegistry;        
        private ModuleProvider m_provider;

        public ModuleBase(ModuleProvider provider) : this()
        {
            m_provider = provider;
        }

        protected ModuleBase()
        {
            m_serviceRegistry = new ServiceRegistry();
        }
        
        public ServiceRegistry Services
        {
            get { return m_serviceRegistry; }
            protected set { m_serviceRegistry = value; }
        }

        public ModuleProvider Provider
        {
            get
            {
                if (m_provider == null)
                    m_provider = Scout.Core.DefaultModuleProvider;

                return m_provider;
            }
            protected set { m_provider = value; }
        }
      
        public T GetService<T>() 
        {
            foreach(KeyValuePair<Type,object> pair in m_serviceRegistry.Registry)
            {
                Type t = pair.Key;
                if(t == typeof(T))
                {
                    return (T)pair.Value;
                }
            }

            return default(T);
        }

        public void RegisterService<T>(T service)
        {
            m_serviceRegistry.Register<T>(service);            
        }

        public string Name
        {
            get { return this.GetType().DeclaringType.ToString(); }
        }
    }
}