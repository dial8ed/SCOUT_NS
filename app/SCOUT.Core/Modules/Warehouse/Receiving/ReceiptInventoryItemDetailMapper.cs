namespace SCOUT.Core.Data
{
    public class ReceiptInventoryItemDetailMapper : Core.IMapper<Receipt,InventoryItem>
    {
        public InventoryItem MapFrom(Receipt input)
        {
            InventoryItem item =
                InventoryRepository.GetItemById(input.Session, input.UnitTrackingId);
                
            if(item == null)
                item = Scout.Core.Data.CreateEntity<InventoryItem>(input.Session);

            item.Part = input.Part;            
            item.LotId = input.UnitTrackingId;
            item.Qty = input.Qty;
            item.Grade = input.Grade;
            item.Tote = input.ReceivingCart;
            item.RoutingRequired = input.RoutingRequired;
            item.CustomFields = input.CustomFields;
            item.SerialNumber = input.SerialNumber;
            item.ShopfloorProgram = input.PurchaseOrder.Program;

            // Copy the program into the receipt record for archival purposes
            input.Program = item.ShopfloorProgram;

            // Map the receive location to the line item spec
            PurchaseLineItem lineItem = input.PurchaseOrder.LineItemByPart(item.Part);
            if(lineItem != null && lineItem.ReceiveDomain != null)
            {
                item.Site = lineItem.ReceiveDomain.Parent.Parent;
                item.Shopfloorline = lineItem.ReceiveDomain.Parent;

                if (item.Tote != null)
                    item.Tote.Domain = lineItem.ReceiveDomain;

                item.ChangeDomain(lineItem.ReceiveDomain);
            }
            // If a line item spec is not defined use the order spec
            else
            {
                item.Site = input.PurchaseOrder.RecDomain.Parent.Parent;
                item.Shopfloorline = input.PurchaseOrder.RecDomain.Parent;

                if (item.Tote != null)
                    item.Tote.Domain = input.PurchaseOrder.RecDomain;

                item.ChangeDomain(input.PurchaseOrder.RecDomain);
            }
            
            return item;
        }
    }
}