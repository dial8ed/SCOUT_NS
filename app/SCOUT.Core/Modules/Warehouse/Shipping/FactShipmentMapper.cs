namespace SCOUT.Core.Data
{
    public class FactShipmentMapper : IMapper<ShipmentFacts, Shipment>
    {
        public Shipment MapFrom(ShipmentFacts input)
        {
            // Mapper should not create entity
            // Well maybe - AutoMapper does...
            Shipment shipment =
                Scout.Core.Data.CreateEntity<Shipment>(input.SalesOrder.Session);
                                           
            shipment.Part = input.Item.Part;
            shipment.Qty = input.ShipQty;
            shipment.Item = input.Item;
            shipment.LineItem = input.SalesOrder.GetLineByPart(input.Item.Part);            
            shipment.DepartureDomain = input.Item.Domain;
            shipment.SalesOrder = input.SalesOrder;
            shipment.Program = input.Item.ShopfloorProgram;
            shipment.LineItemIdentifier = input.LineItemIdentifier;

            return shipment;
        }
    }
}