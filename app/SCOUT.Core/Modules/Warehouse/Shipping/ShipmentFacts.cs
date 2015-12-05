namespace SCOUT.Core.Data
{
    public class ShipmentFacts
    {
        public ShipmentFacts(SalesOrder salesOrder, InventoryItem item, int shipQty, string lineItemIdentifier, OrderAllocationDetails allocationDetails)
        {
            SalesOrder = salesOrder;
            Item = item;
            ShipQty = shipQty;
            LineItemIdentifier = lineItemIdentifier;
            AllocationDetails = allocationDetails;
        }

        public SalesOrder SalesOrder { get; private set; }

        public InventoryItem Item { get; private set; }

        public int ShipQty { get; private set; }

        public string LineItemIdentifier { get; private set; }

        public OrderAllocationDetails AllocationDetails { get; set; }

    }
}