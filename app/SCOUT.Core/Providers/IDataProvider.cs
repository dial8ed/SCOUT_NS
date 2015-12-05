using System;
using System.Collections;
using SCOUT.Core.Mvc;

namespace SCOUT.Core.Data
{
    public interface IDataProvider : IRepository
    {
        XpoUnitOfWork GetUnitOfWork();
        Providers.Data.IRepository GetRepository(IUnitOfWork uow);
    }
   
    public interface IUnitOfWork : ISession
    {
        void Commit();
        bool Delete(object entity, bool commitChanges);
        ICollection GetObjectsToSave();
        ICollection GetObjectsToDelete();
        bool InTransaction { get; }
        void RollbackTransaction();
        void ReloadChangedObjects();
        void PurgeDeletedObjects();
        bool HasChanges();

        event EventHandler<LockingExceptionEventArgs> OnLockingException;

    }
}