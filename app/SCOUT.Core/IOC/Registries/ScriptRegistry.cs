using SCOUT.Core.Data;
using StructureMap.Configuration.DSL;

namespace SCOUT.Core.IOC.Registries
{
    public class ScriptRegistry : Registry
    {
        public ScriptRegistry()
        {
            For<IShipmentScript>().Use<ShipmentScript>();
        }
    }
}