namespace SCOUT.Core.Data
{
    public class MaterialReceiptValidator : ValidatorBase
    {
        private MaterialPurchaseOrder m_order;
        private Part m_part;
        private int m_qty;
     
        public MaterialReceiptValidator(MaterialPurchaseOrder order, Part part, int qty)
        {
            m_order = order;
            m_part = part;
            m_qty = qty;
        }

        public override void GetError()
        {
            MaterialPurchaseLineItem lineItem = m_order.GetLineItemForPart(m_part);

            if(lineItem == null)
            {
                m_error = "No line items found for this part";
                return;
            }

            if (lineItem.Status != LineItemStatus.Open)
            {
                m_error = "The line for this part is not open.";
                return;
            }

            if((lineItem.ProcessedQty + m_qty) > lineItem.Quantity)
            {
                m_error = "You cannot receive more than is expected.";
                return;
            }
                                        
        }
    }
}