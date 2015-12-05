using System;
using DevExpress.Xpo;
using SCOUT.Core.Providers.Data;

namespace SCOUT.Core.Data
{
    public class XpoDataProvider : IDataProvider
    {
        public XpoUnitOfWork GetUnitOfWork()
        {
            return new XpoUnitOfWork(XpoDefault.DataLayer);
        }

        public Providers.Data.IRepository GetRepository(IUnitOfWork uow)
        {
            return new XpoRepository(uow);
        }

        public RepositoryList<T> GetList<T>(IUnitOfWork uow)
        {
            return Repository.GetList<T>(uow);
        }

        public RepositoryItem<T> Get<T>(IUnitOfWork uow)
        {
            return Repository.Get<T>(uow);
        }

        public bool Save(IUnitOfWork uow)
        {
            return Repository.Save(uow);
        }

        public bool Delete(IUnitOfWork uow, object entity, bool commitChanges)
        {
            return Repository.Delete(uow,entity, commitChanges);
        }

        public T CreateEntity<T>(IUnitOfWork uow)
        {
            UnitOfWork xpoUow = uow as UnitOfWork;
            if (xpoUow != null)
                return (T)Activator.CreateInstance(typeof (T), new object[] {xpoUow});

            return default(T);
        }
    }
}