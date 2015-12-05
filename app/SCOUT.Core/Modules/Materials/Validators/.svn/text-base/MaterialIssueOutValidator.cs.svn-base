namespace SCOUT.Core.Data
{
    public class MaterialIssueOutValidator : ValidatorBase
    {
        private readonly MaterialWarehouseItem m_item;
        private readonly Shopfloorline m_shopfloorline;
        private readonly int m_qty;

        public MaterialIssueOutValidator(MaterialWarehouseItem item, Shopfloorline shopfloorline, int qty)
        {
            m_item = item;
            m_shopfloorline = shopfloorline;
            m_qty = qty;           
        }


        public override void GetError()
        {         
                if(m_qty > m_item.Qty)
                {
                    m_error = "You cannot issue out more than available.";
                    return;
                }

        }
    }
}