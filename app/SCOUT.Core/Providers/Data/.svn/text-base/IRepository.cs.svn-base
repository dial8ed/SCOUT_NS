using System;
using System.Linq;
using System.Linq.Expressions;
using SCOUT.Core.Data;

namespace SCOUT.Core.Providers.Data
{
    public interface IRepository
    {
        T Get<T>(Expression<Func<T, bool>> conditions);        
        T GetAndCreateIfNotFound<T>(Expression<Func<T,bool>> conditions, Action<T> createMapping);
        T GetAndDefaultIfNotFound<T, Default>(Expression<Func<T, bool>> conditions) where Default : T;
        bool Save();
        T Create<T>();
        IUnitOfWork UnitOfWork { get; }
        IQueryable<T> Find<T>();


    }
}