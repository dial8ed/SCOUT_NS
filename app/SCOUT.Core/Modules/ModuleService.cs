using SCOUT.Core.Data;
using SCOUT.Core.Providers;

namespace SCOUT.Core.Modules
{
    public abstract class ModuleService
    {
        private IModule m_module;        
 
        protected ModuleService(IModule module)
        {
            m_module = module;           
        }
   
        protected IModule Module
        {
            get { return m_module; }
            set { m_module = value; }
        }

        protected IUserInteractionProvider UserInteraction
        {
            get { return Providers.UserInteraction; }
        }

        protected IDataProvider Data
        {
            get { return Providers.Data; }
        }

        protected ILoggingProvider Logging
        {
            get { return Providers.Logging; }
        }

        public ModuleProvider Providers
        {
            get { return m_module.Provider; }
        }
    }
}