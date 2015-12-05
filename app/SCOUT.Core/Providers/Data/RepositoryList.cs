using System.Collections.Generic;
using DevExpress.Data.Filtering;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Provides the methods for getting Lists 
    /// </summary>
    /// <typeparam name="T">The type of class to get a list of</typeparam>
    public class RepositoryList<T> 
    {
        private IUnitOfWork m_unitOfWork;
        
        public RepositoryList(IUnitOfWork uow)
        {
            m_unitOfWork = uow;
        }

        /// <summary>
        /// Gets all the objects of type T from the datastore.
        /// </summary>
        /// <returns></returns>
        public ICollection<T> All()
        {
            return m_unitOfWork.GetAllObjects<T>();       
        }

        public ICollection<T> Top(int top)
        {
            return m_unitOfWork.GetTopObjects<T>(top);
                      
        }
        
        /// <summary>
        /// Gets all the objects that match some criteria from the datastore.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public ICollection<T> ByCriteria(CriteriaOperator criteria)
        {            
            return m_unitOfWork.FindObjects<T>(criteria);                        
        }
    }
}