using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace SCOUT.Core.Data
{
    public class XPOFactory
    {
        public static T GetInstanceOfById<T>(object id)
        {
            IUnitOfWork m_session = Scout.Core.Data.GetUnitOfWork();

            int intId;
            Int32.TryParse(id.ToString(), out intId);

            if(intId > 0)
                id = intId;
        
            return m_session.GetObjectByKey<T>(id);                                  
        }
    }
}