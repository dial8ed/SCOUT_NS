namespace SCOUT.Core.Data
{
    internal class ScheduledLineStatusUpdater : IShippingLineStatusManager
    {
        public LineItemStatus GetStatusAfterShipment(SalesLineItem lineItem, int qty)
        {            
            if (lineItem.Quantity == (lineItem.ProcessedQty + qty))
                return LineItemStatus.Closed;

            if (lineItem.OpenQty == 0)
                return LineItemStatus.Scheduled;

            return lineItem.Status;

        }

        public LineItemStatus GetStatusAfterUnship(SalesLineItem lineItem, int qty)
        {
            if (lineItem.Quantity > (lineItem.ProcessedQty - qty))
                return LineItemStatus.Open;

            return lineItem.Status;
        }
    }
}