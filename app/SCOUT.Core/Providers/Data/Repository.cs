using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SCOUT.Core.Messaging;
using SCOUT.Core.Providers.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Repository interface for getting single objects and lists of 
    /// objects from the data store.
    /// </summary>
    public class Repository
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static RepositoryItem<T> Get<T>(IUnitOfWork uow)
        {
            return new RepositoryItem<T>(uow);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static RepositoryList<T> GetList<T>(IUnitOfWork uow)
        {
            return new RepositoryList<T>(uow);
        }


        public static IEnumerable<T> Find<T>(IUnitOfWork uow)
        {
            return QueryFactory.NewQuery<T>(uow);
        }

        public static bool Save(IUnitOfWork uow)
        {
            try
            {
                uow.Commit();                
                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);                
            }

            return false;
        }

        public static bool Delete<T>(IUnitOfWork uow, T entity, bool commitChanges)
        {
            return uow.Delete(entity, commitChanges);
        }

    }
}