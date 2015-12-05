using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Providers.Data
{
    public class XpoQuery<T>
    {
        private XPQuery<T> m_query;

        public XpoQuery(IUnitOfWork uow)
        {
            m_query = new XPQuery<T>(uow as UnitOfWork);
        }

        public IEnumerable<T> Get
        {
            get { return m_query; }
        }

    }
}