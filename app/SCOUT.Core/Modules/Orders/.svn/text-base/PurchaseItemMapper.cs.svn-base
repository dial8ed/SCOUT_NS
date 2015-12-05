namespace SCOUT.Core.Data
{
    public class PurchaseItemMapper : Core.IMapper<SalesLineItem, PurchaseLineItem>
    {
        public PurchaseLineItem MapFrom(SalesLineItem input)
        {
            PurchaseLineItem lineItem = Scout.Core.Data.CreateEntity<PurchaseLineItem>(input.Session);
            lineItem.Part = input.Part;
            lineItem.Quantity = (int)input.Quantity;
            return lineItem;
        }
    }
}