using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteCreateCommandArguments : ICommandArguments
    {
        private IUnitOfWork m_unitOfWork;
        private ToteType m_toteType;

        public ToteCreateCommandArguments(IUnitOfWork unitOfWork, ToteType toteType)
        {
            m_unitOfWork = unitOfWork;
            m_toteType = toteType;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return m_unitOfWork; }
        }

        public ToteType ToteType
        {
            get { return m_toteType; }
        }

        public object[] Arguments
        {
            get { return new object[] {this}; }
        }
    }
}