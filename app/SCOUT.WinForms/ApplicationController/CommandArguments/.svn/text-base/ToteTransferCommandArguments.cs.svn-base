using System;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteTransferCommandArguments : ICommandArguments
    {
        private Tote m_tote;

        public ToteTransferCommandArguments(Tote tote)
        {
            m_tote = tote;
        }

        public Tote Tote
        {
            get { return m_tote; }
        }

        public object[] Arguments
        {
            get { return new object[]{this,m_tote};}
        }
    }
}