namespace SCOUT.Core.Data
{
    public class MaterialLocationTransferValidator : ValidatorBase
    {
        private readonly MaterialWarehouseItem m_item;
        private readonly Domain m_domain;
        private readonly string m_location;
        private readonly int m_qty;

        public MaterialLocationTransferValidator(MaterialWarehouseItem item, Domain domain, string location, int qty)
        {
            m_item = item;
            m_domain = domain;
            m_location = location;
            m_qty = qty;            
        }

        public override void GetError()
        {
            if(m_qty > m_item.Qty)
            {
                m_error = "You cannot transfer more than is available.";
                return;
            }
        }
    }
}