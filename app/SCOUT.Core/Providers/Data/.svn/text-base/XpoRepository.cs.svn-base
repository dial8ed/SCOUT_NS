using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Utils;

namespace SCOUT.Core.Providers.Data
{
    public class XpoRepository : IRepository
    {
        private IUnitOfWork m_uow;

        public XpoRepository(IUnitOfWork uow)
        {
            if(!(uow is UnitOfWork))
                throw new NotSupportedException("Xpo UnitOfWork must be of type DevExpress.Xpo.UnitOfWork");

            m_uow = uow;
        }

        public T Get<T>(Expression<Func<T,bool>> expression)
        {
            var op = new XPQuery<T>(m_uow as UnitOfWork).TransformExpression(expression);            
            return m_uow.FindObject<T>(op);
        }


        public T GetAndCreateIfNotFound<T>(Expression<Func<T, bool>> conditions, Action<T> createMapping)
        {
            var obj = Get(conditions);

            if (obj == null)
                createMapping(obj = Create<T>());
            
            return obj;
        }

        public T GetAndDefaultIfNotFound<T,Default>(Expression<Func<T, bool>> condition) where Default : T
        {
            var obj = Get<T>(condition);

            if (obj == null)
                return Create<Default>();

            return obj;
        }

        public bool Save() 
        {                        
            return ExecutionHelpers.TryCatch(() => m_uow.Commit());
        }

        public T Create<T>()
        {
            return Reflection.CreateInstanceOfType<T>(m_uow);
        }

        public IQueryable<T> Find<T>()
        {
            return QueryFactory.NewQuery<T>(m_uow);
        }

        public IUnitOfWork UnitOfWork
        {
            get { return m_uow as IUnitOfWork; }
        }
    }
}