using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace SCOUT.Core.Data
{
    public interface ISession
    {
        T GetObjectByKey<T>(object id);
        T FindObject<T>(CriteriaOperator criteriaOperator);
        T FindObject<T>(string criteria);

        ICollection<T> FindObjects<T>(string criteria);
        ICollection<T> FindObjects<T>(CriteriaOperator criteria);
        ICollection<T> GetAllObjects<T>();
        ICollection<T> GetTopObjects<T>(int top);
      
    }
}