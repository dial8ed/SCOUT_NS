using SCOUT.Core.Modules.Orders;

namespace SCOUT.Core.Modules
{
    public class OrderModule : ModuleBase, IOrderModule
    {
        private IOrderData m_data;
        public OrderModule()
        {
            m_data = new OrderData();
        }

        public IOrderData Data
        {
            get { return m_data; }
        }      
    }
}