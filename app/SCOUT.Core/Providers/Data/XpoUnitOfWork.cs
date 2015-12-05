using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using SCOUT.Core.Messaging;
using SCOUT.Core.Mvc;

namespace SCOUT.Core.Data
{
    public class XpoUnitOfWork : UnitOfWork, IUnitOfWork 
    {
        public XpoUnitOfWork(IDataLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect)
        {

        }

        public T FindObject<T>(string criteria)
        {
            CriteriaOperator op1 = CriteriaOperator.Parse(criteria);
            return FindObject<T>(op1);
        }

        public ICollection<T> FindObjects<T>(string criteria) 
        {
            CriteriaOperator op1 = CriteriaOperator.Parse(criteria);
            return new XPCollection<T>(this, op1);
        }

        public ICollection<T> FindObjects<T>(CriteriaOperator criteria)
        {
            return new XPCollection<T>(this, criteria);
        }

        public ICollection<T> GetAllObjects<T>()
        {
            return new XPCollection<T>(this);            
        }

        public ICollection<T> GetTopObjects<T>(int top)
        {
            XPCollection<T> collection = new XPCollection<T>(this, false);
            collection.TopReturnedObjects = top;
            collection.LoadingEnabled = true;
            collection.Load();

            return collection;
        }

        #region Obsolete Methods

        public ICollection<T> FindObjects<T>(Session uow, string criteria)
        {
            CriteriaOperator op1 = CriteriaOperator.Parse(criteria);
            return new XPCollection<T>(uow as UnitOfWork, op1);
        }

        public ICollection<T> FindObjects<T>(Session uow, CriteriaOperator criteria)
        {
            return new XPCollection<T>(uow as UnitOfWork, criteria);
        }

        public ICollection<T> GetAllObjects<T>(Session uow)
        {
            return new XPCollection<T>(uow as UnitOfWork);
        }


        #endregion

        public void Commit()
        {
            try
            {
                CommitChanges();
            }
            catch (LockingException)
            {   
                if(OnLockingException != null)                    
                    OnLockingException(this, new LockingExceptionEventArgs(this));
            }
            
        }

        public bool Delete(object entity, bool commitChanges)
        {      
            try
            {           
                base.Delete(entity);                
                PurgeDeletedObjects();

                if (commitChanges)
                    Commit();

                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
            }

            return false;            
        }

        public bool HasChanges()
        {
           return GetObjectsToDelete().Count > 0 || GetObjectsToSave().Count > 0;           
        }

        public event EventHandler<LockingExceptionEventArgs> OnLockingException;


        

        new public void PurgeDeletedObjects()
        {
            base.PurgeDeletedObjects();
        }
    }
}