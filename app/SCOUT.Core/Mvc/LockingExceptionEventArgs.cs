using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public class LockingExceptionEventArgs : EventArgs
    {
        private IUnitOfWork m_unitOfWork;

        public LockingExceptionEventArgs(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return m_unitOfWork; }
            set { m_unitOfWork = value; }
        }
    }
}