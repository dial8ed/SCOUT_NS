using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Providers.Data
{
    public static class QueryFactory 
    {
        public static IQueryable<T> NewQuery<T>()
        {
            return NewQuery<T>(Scout.Core.Data.GetUnitOfWork());
        }

        public static IQueryable<T> NewQuery<T>(IUnitOfWork uow)
        {
            return new XPQuery<T>(uow as UnitOfWork);
        }        
    }
}