namespace SCOUT.Core.Data
{
    public class SalesLineItemShipmentValidator : ValidatorBase
    {
        private SalesLineItem m_lineItem;

        public SalesLineItemShipmentValidator(SalesLineItem lineItem)
        {
            m_lineItem = lineItem;
        }

        public override void GetError()
        {
            if(!LineItemIsOpen()) return;
            if(!ReturnNReplaceLineIsShippable()) return;
            if(!AdexLineIsShippable()) return;
        }

        private bool AdexLineIsShippable()
        {
            return true;
        }

        private bool ReturnNReplaceLineIsShippable()
        {
            return true;

            if (m_lineItem.SalesOrder.Order.OrderType == OrderType.ReturnNReplace)
            {
                PurchaseOrder po =
                    m_lineItem.SalesOrder.Order.GetContract<PurchaseOrder>() as PurchaseOrder;

                if (po != null)
                {
                    //PurchaseLineItem pli = po.LineItemByPart(m_lineItem.Part);
                    if (po.OutgoingPartProcessedQty(m_lineItem.Part) <= m_lineItem.ProcessedQty)
                    {
                        m_error = "This line cannot be shipped against until more units are received for this part.";
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
                m_error = "This line item is not open and cannot be shipped against.";
                return false;
            }

            return true;
        }
    }
}