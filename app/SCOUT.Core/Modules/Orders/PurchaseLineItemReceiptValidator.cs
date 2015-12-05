namespace SCOUT.Core.Data
{
    public class PurchaseLineItemReceiptValidator : ValidatorBase
    {
        private PurchaseLineItem m_lineItem;
        public PurchaseLineItemReceiptValidator(PurchaseLineItem lineItem)
        {
            m_lineItem = lineItem;
        }

        public override void GetError()
        {
            // Blanket PO. No line item rules to verify.
            if(m_lineItem == null)
                return;

            if(!LineItemIsOpen()) return;                   
            if(!AdexLineItemIsReceivable()) return;
        }

        private bool AdexLineItemIsReceivable()
        {
            return true;

            if (m_lineItem.PurchaseOrder.Order.OrderType == OrderType.ADEX)
            {
                SalesOrder so =
                    m_lineItem.PurchaseOrder.Order.GetContract<SalesOrder>() as SalesOrder;

                if (so != null)
                {
                    SalesLineItem sli = so.GetLineByPart(m_lineItem.Part);

                    if (sli.ProcessedQty <= m_lineItem.ProcessedQty)
                    {
                        m_error = "This line cannot be received against until more units are shipped for this part.";
                        return false;
                    }
                }
            }

            return true;
        }

        private bool LineItemIsOpen()
        {
            if (m_lineItem.Status != LineItemStatus.Open)
            {
                m_error = "This line item is not open and cannot be received against.";
                return false;
            }

            return true;
        }
    }
}