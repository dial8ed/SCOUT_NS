namespace SCOUT.Core.Data
{
    public interface IRepository
    {
        RepositoryList<T> GetList<T>(IUnitOfWork uow);
        RepositoryItem<T> Get<T>(IUnitOfWork uow);
        bool Save(IUnitOfWork uow);
        bool Delete(IUnitOfWork uow, object entity, bool commitChanges);
        T CreateEntity<T>(IUnitOfWork uow);

    }
}