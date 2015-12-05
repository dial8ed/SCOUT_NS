using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public abstract class PersistentModel : IPersistentModel
    {
        private IUnitOfWork m_unitOfWork;

        protected PersistentModel(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }

        protected PersistentModel()
        {
            m_unitOfWork = Scout.Core.Data.GetUnitOfWork();
        }

        public IUnitOfWork UnitOfWork
        {
            get { return m_unitOfWork; }            
        }
    
    }
}