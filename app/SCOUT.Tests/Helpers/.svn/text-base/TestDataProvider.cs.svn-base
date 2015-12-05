using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Tests.Domain;
using IRepository = SCOUT.Core.Providers.Data.IRepository;

namespace SCOUT.Tests.Helpers
{
    public class TestDataProvider : IDataProvider
    {
        public XpoUnitOfWork GetUnitOfWork()
        {
            return Xpo.UnitOfWork();
        }

        public IRepository GetRepository(IUnitOfWork uow)
        {
            throw new NotImplementedException();
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
            return Repository.Delete(uow, entity, commitChanges);
        }

        public T CreateEntity<T>(IUnitOfWork uow)
        {
            return Reflection.CreateInstanceOfType<T>(Xpo.UnitOfWork());
        }
    }
}