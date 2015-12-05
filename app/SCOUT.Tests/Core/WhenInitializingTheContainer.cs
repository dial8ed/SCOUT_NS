using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Core.IOC;

namespace SCOUT.Tests.Core
{
    [TestFixture] 
    public class WhenInitializingTheContainer
    {
        [SetUp] 
        public void SetUp()
        {
            BootstrapContainer.Initialize();
        }

        [Test] 
        public void the_container_should_be_able_to_retrieve_registered_mappers()
        {
            var mapper = Scout.Core.Mapping.GetMapper<ShipmentFacts, Shipment>();
            Assert.IsInstanceOf<FactShipmentMapper>(mapper);
        }

        [Test] 
        public void the_container_should_be_able_to_retrieve_registered_scripts()
        {
            var script = Scout.Core.Container.GetInstance<IShipmentScript>();
            Assert.IsInstanceOf<ShipmentScript>(script);                        
        }

        [Test] 
        public void the_shipment_script_should_be_initialized_with_constructor_args()
        {
            var script = Scout.Core.Container.GetInstance<IShipmentScript>();
            Assert.IsInstanceOf<ShipmentScript>(script);
            Assert.IsInstanceOf<FactShipmentMapper>(((ShipmentScript) script).ShipmentMapper);
            Assert.IsInstanceOf<ShipmentTransactionMapper>(((ShipmentScript)script).TransactionMapper);
        }
        
    }
}