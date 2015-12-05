namespace SCOUT.Core.Data
{
    public class SalesItemMapper : Core.IMapper<PurchaseLineItem,SalesLineItem>
    {
        public SalesLineItem MapFrom(PurchaseLineItem input)
        {            
            SalesLineItem lineItem = Scout.Core.Data.CreateEntity<SalesLineItem>(input.Session);
            lineItem.Part = input.Part;
            lineItem.Quantity = input.Quantity;

            return lineItem;
        }
    }
}