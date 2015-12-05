using NUnit.Framework;
using SCOUT.Core.Modules.Warehouse.Inventory;

namespace SCOUT.Tests.Extensions
{
    [TestFixture]
    public class InventoryExtensions
    {

        [Test]
        public void can_prefix_adjustment_source_type_codes()
        {
            var list = AdjustmentTransactionType.AsList();
            Assert.That(list.PrefixCodesWith("MATL")[0].Code.StartsWith("MATL"));
        }        
    }
}