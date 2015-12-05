namespace SCOUT.Core.Data
{
    public class MaterialWarehouseReturnValidator : ValidatorBase
    {
        private readonly MaterialConsumableItem m_item;
        private readonly Domain m_domain;
        private readonly int m_qty;

        public MaterialWarehouseReturnValidator(MaterialConsumableItem item, Domain domain, int qty)
        {
            m_item = item;
            m_domain = domain;
            m_qty = qty;            
        }

        public override void GetError()
        {
            if(m_qty > m_item.Qty)
            {
                m_error = "You can return more than has been issued out";
                return;
            }            
        }
    }
}