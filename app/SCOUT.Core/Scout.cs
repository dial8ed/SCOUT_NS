using System;
using SCOUT.Core.Data;
using SCOUT.Core.IOC;
using SCOUT.Core.Modules;
using SCOUT.Core.Providers;
using SCOUT.Core.Providers.Container;
using SCOUT.Core.Providers.Mapping;

namespace SCOUT
{
    /// <summary>
    /// Application Core
    /// </summary>
    public class Scout
    {
        private Modules m_modules;
        private ModuleProvider m_defaultModuleProvider;
        private static Scout m_instance;
        private IMappingProvider m_mappingProvider;
        private IContainerProvider m_containerProvider;

        /// <summary>
        /// Singleton interface
        /// </summary>
        public static Scout Core
        {
            get 
            { 
                if(m_instance == null)
                    m_instance = new Scout();
              
                return m_instance;            
            }
        }

        private Scout()
        {
            m_modules = new Modules();
            m_mappingProvider = new AutoMapperMappingProvider();
            m_containerProvider = new ContainerProvider();
            BootstrapContainer.Initialize();
        }

        /// <summary>
        /// Fluid interface for interacting with the modules by name ie: Warehouse
        /// </summary>
        public Modules Modules
        {
            get { return m_modules; }
        }

        /// <summary>
        /// Gets or sets the default module provider of the core.        
        /// </summary>
        public ModuleProvider DefaultModuleProvider
        {
            get
            {
                if (m_defaultModuleProvider == null)
                    throw new NullReferenceException("The default module provider for SCOUT.Core has not been set.");

                return m_defaultModuleProvider;
            }
            set { m_defaultModuleProvider = value; }
        }

        /// <summary>
        /// Shortcut into the cores DefaultModuleProvider.UserInteraction provider
        /// </summary>
        public IUserInteractionProvider UserInteraction
        {
            get { return DefaultModuleProvider.UserInteraction; }
        }

        public IDataProvider Data
        {
            get { return DefaultModuleProvider.Data; }
        }

        public ILoggingProvider Logging
        {
            get { return DefaultModuleProvider.Logging; }
        }

        public IMappingProvider Mapping
        {
            get { return m_mappingProvider; }
        }

        public IContainerProvider Container
        {
            get { return m_containerProvider; }
        }

        /// <summary>
        /// Iterates through the registered modules seeking to return the requested module
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Module<T>() where T : class
        {           
            foreach(IModule module in m_modules.AllModules())
            {
                if (module is T)
                    return (T)module;
            }

            throw new Exception("There is no module registered for: " + typeof(T).ToString());
        }

        /// <summary>
        /// Iterates through each service in each registered module 
        /// seeking to return the requested service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Service<T>()
        {           
            foreach (IModule module in Modules.AllModules())
            {
                object service = null;
                service = module.GetService<T>();

                if (service != null)
                    return (T) service;             
            }

            throw new Exception("There is no service registered for: " + typeof(T).ToString());
        }
    }
}