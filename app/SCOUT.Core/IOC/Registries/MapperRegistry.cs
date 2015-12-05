using SCOUT.Core.Data;
using StructureMap.Configuration.DSL;

namespace SCOUT.Core.IOC.Registries
{
    public class MapperRegistry : Registry
    {
        public MapperRegistry()
        {
            For<IMapper<ShipmentFacts, Shipment>>()
                .Use(() => new FactShipmentMapper());

            For<IMapper<Shipment, Transaction>>()
                .Use(() => new ShipmentTransactionMapper());
        }
    }
}