using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Core
{

    /// <summary>
    /// Gets a inventory item and returns it
    /// </summary>
    public class InventoryGetItemCommand : Command, IOutputCommand<InventoryItem>
    {
        private InventoryItem m_item;
        private IUnitOfWork m_session;
        private string m_lookupKey;

        // param 0 - lookup key (lotid or sn)
        // param 1 - UnitOfWork
        public InventoryGetItemCommand(params object[] input) : base(input)
        {
            m_session = input[1] as IUnitOfWork;
            m_lookupKey = input[0] as string;
        }

        public override void Execute()
        {
            m_item = new InventoryLocator().LocateOrWarn(m_session, m_lookupKey);

            //// Try getting the inventory item by lotid
            //m_item = Scout.Core.Service<IInventoryService>().GetItemById(m_session, m_lookupKey);

            //// Try getting the inventory item by serial number
            //if (m_item == null)
            //    m_item = Scout.Core.Service<IInventoryService>().GetItemBySN(m_session, m_lookupKey);          
        }

        public InventoryItem Output
        {
            get
            {
                return m_item;
            }
        }
    }
}