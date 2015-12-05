using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteRemoveItemsCommandArguments : ICommandArguments
    {
        private List<InventoryItem> m_itemsToRemove;
        private IUnitOfWork m_session;
        private Tote m_tote;

        public ToteRemoveItemsCommandArguments(Tote tote)
        {
            m_session = tote.Session;
            m_tote = tote;
            m_itemsToRemove = new List<InventoryItem>();
        }

        public IUnitOfWork Session
        {
            get { return m_session; }
        }

        public void AddItemToRemove(InventoryItem item)
        {
            if(!m_itemsToRemove.Contains(item))
                m_itemsToRemove.Add(item);            
        }

        public List<InventoryItem> ItemsToRemove
        {
            get { return m_itemsToRemove; }
        }

        public object[] Arguments
        {
            get
            {               
                return new object[]{this};
            }
        }
    }
}