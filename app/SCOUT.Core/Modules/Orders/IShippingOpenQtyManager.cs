namespace SCOUT.Core.Data
{
    internal interface IShippingOpenQtyManager
    {
        int GetOpenQty(SalesLineItem lineItem);
    }
}