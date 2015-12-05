namespace SCOUT.Core.Data
{
    internal interface IShippingLineStatusManager
    {
        LineItemStatus GetStatusAfterShipment(SalesLineItem lineItem, int qty);
        LineItemStatus GetStatusAfterUnship(SalesLineItem lineItem, int qty);
    }
}