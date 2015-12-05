using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Providers.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a single item in the datastore.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryItem<T>
    {
        private IUnitOfWork m_unitOfWork;
        public RepositoryItem(IUnitOfWork uow)
        {
            m_unitOfWork = uow;
        }

        /// <summary>
        /// Gets a object of type T from the datastore by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public T ById(object id) 
        {
            return m_unitOfWork.GetObjectByKey<T>(id);            
        }

        /// <summary>
        /// Gets the object of type T from the datastore by Criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public T ByCriteria(CriteriaOperator criteria)
        {
            return m_unitOfWork.FindObject<T>(criteria);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public T ByCriteria(string criteria)
        {
            return m_unitOfWork.FindObject<T>(criteria);
        }

        public IEnumerable<T> Get()
        {
            return QueryFactory.NewQuery<T>(m_unitOfWork);
        }
    }
}