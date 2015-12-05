using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteContentsTransferCommandArguments : ICommandArguments
    {
        private Tote m_currentTote;
        private List<InventoryItem> m_itemsToMove;
        private IUnitOfWork m_session;

        public ToteContentsTransferCommandArguments(Tote currentTote)
        {
            m_currentTote = currentTote;
            m_itemsToMove = new List<InventoryItem>();
            m_session = m_currentTote.Session;
        }

        public Tote CurrentTote
        {
            get { return m_currentTote; }
        }

        public void AddItemToMove(InventoryItem item)
        {            
            if(!m_itemsToMove.Contains(item))
                m_itemsToMove.Add(item);
        }

        public List<InventoryItem> ItemsToMove
        {
            get { return m_itemsToMove; }
        }

        public IUnitOfWork Session
        {
            get { return m_session; }
        }

        #region ICommandArguments Members

        public object[] Arguments
        {
            get { return new object[] {this}; }
        }

        #endregion
    }
}