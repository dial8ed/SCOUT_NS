using System;
using SCOUT.Core.Data;

namespace SCOUT.Core.Providers
{
    public class DatabaseLoggingProvider : ILoggingProvider
    {
        private IUnitOfWork m_uow;

        public DatabaseLoggingProvider()
        {
            m_uow = Scout.Core.Data.GetUnitOfWork();
        }

        public void Log(string message, LogType type)
        {          
            DatabaseLogEntry log =  
              Scout.Core.Data.CreateEntity<DatabaseLogEntry>(m_uow);

            log.Message = message;
            log.Type = type;

            Scout.Core.Data.Save(m_uow);            
        }
    }
}