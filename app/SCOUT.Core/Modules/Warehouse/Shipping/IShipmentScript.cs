namespace SCOUT.Core.Data
{
    public interface IShipmentScript
    {
        bool Run(ShipmentFacts shipmentFacts,
                 Packlist packlist);
      
    }
}