using SCOUT.Core.Providers;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class ModuleProvider
    {
        private ServiceRegistry m_registry;

        public ModuleProvider()
        {
            m_registry = new ServiceRegistry();            
        }
        
        private T Service<T>() 
        {
            return (T)m_registry.Registry[typeof (T)];
        }
           
        public IUserInteractionProvider UserInteraction
        {
            get { return Service<IUserInteractionProvider>(); }
            set
            {
                if(value != null)
                    m_registry.Register<IUserInteractionProvider>(value);
            }
        }

        public IDataProvider Data
        {
            get { return Service<IDataProvider>(); }
            set
            {
                if(value != null)
                    m_registry.Register<IDataProvider>(value);
            }
        }

        public IWorkflowProvider Workflow
        {
            get { return Service<IWorkflowProvider>(); }
            set
            {
                if (value != null)
                    m_registry.Register<IWorkflowProvider>(value);
            }
        }

        public ILoggingProvider Logging
        {
            get { return Service<ILoggingProvider>(); }
            set
            {
                if (value != null)
                    m_registry.Register<ILoggingProvider>(value);
            }
        }
    }
}