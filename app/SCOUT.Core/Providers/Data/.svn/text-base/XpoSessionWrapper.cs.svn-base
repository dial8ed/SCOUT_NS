using System;
using System.Collections;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using SCOUT.Core.Messaging;
using SCOUT.Core.Data;
using SCOUT.Core.Mvc;

namespace SCOUT.Core.Data
{
    public class XpoSessionWrapper : IUnitOfWork
    {
        private Session m_session;

        public XpoSessionWrapper(Session session)
        {
            m_session = session;
        }

        public T GetObjectByKey<T>(object id)
        {
            return m_session.GetObjectByKey<T>(id);
        }

        public T FindObject<T>(CriteriaOperator criteriaOperator)
        {
            return m_session.FindObject<T>(criteriaOperator);
        }

        public T FindObject<T>(string criteria)
        {
            return FindObject<T>(CriteriaOperator.Parse(criteria));
        }

        public ICollection<T> FindObjects<T>(string criteria)
        {
            return FindObjects<T>(CriteriaOperator.Parse(criteria));
        }

        public ICollection<T> FindObjects<T>(CriteriaOperator criteria)
        {
            return new XPCollection<T>(m_session, criteria);
        }

        public ICollection<T> GetAllObjects<T>()
        {
            return new XPCollection<T>(m_session);
        }

        public ICollection<T> GetTopObjects<T>(int top)
        {
            XPCollection<T> collection = new XPCollection<T>(m_session, false);
            collection.TopReturnedObjects = top;
            collection.LoadingEnabled = true;
            collection.Load();

            return collection;
        }

        public void Commit()
        {
            try
            {
                m_session.CommitTransaction();
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
                m_session.Delete(entity);

                if(commitChanges)
                {
                    m_session.PurgeDeletedObjects();
                    m_session.CommitTransaction();
                }
                    
                   
                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
            }

            return false;  
        }

        public ICollection GetObjectsToSave()
        {
            return m_session.GetObjectsToSave();            
        }

        public ICollection GetObjectsToDelete()
        {
            return m_session.GetObjectsToDelete();
        }

        public bool InTransaction
        {
            get { return m_session.InTransaction; }
        }

        public void RollbackTransaction()
        {
            m_session.RollbackTransaction();
        }

        public void ReloadChangedObjects()
        {
            throw new NotSupportedException("ReloadChangedObjects is not support on Xpo.Session");
        }

        public void PurgeDeletedObjects()
        {
            m_session.PurgeDeletedObjects();
        }

        public bool HasChanges()
        {
            return GetObjectsToDelete().Count > 0 || GetObjectsToSave().Count > 0;
        }

        public event EventHandler<LockingExceptionEventArgs> OnLockingException;
    }
}