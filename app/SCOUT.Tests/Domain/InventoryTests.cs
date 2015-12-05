using System.Linq;
using NUnit.Framework;
using SCOUT.Core.Modules.Warehouse.Inventory;

namespace SCOUT.Tests.Domain
{
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void can_get_all_inventory_adjustment_transaction_types()
        {
            var sut = AdjustmentTransactionType.AsList();

            Assert.That(sut.Where(a => a.Direction == "IN").Count() > 0,
                        "Unable to get adjustment types with IN direction!");   

            Assert.That(sut.Where(a => a.Direction == "OUT").Count() > 0,
                        "Unable to get adjustment types with OUT direction!");
        }        
    }
}