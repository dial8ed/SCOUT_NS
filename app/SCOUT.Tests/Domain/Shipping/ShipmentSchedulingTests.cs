using NUnit.Framework;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain.Shipping
{
    [TestFixture]
    public class ShipmentSchedulingTests
    {

        [Test]
        public void when_initialiazing_defaults_on_a_sales_line_item_a_default_schedule_should_be_created()
        {
            var sli = Xpo.CreateXPObject<SalesLineItem>();

            sli.CreateDefaults();

            Assert.IsTrue(sli.GetDefaultSchedule() != null);
        }

        [Test]
        public void when_setting_the_qty_of_a_line_item_the_default_schedule_should_get_set_to_the_new_qty()
        {
            var sli = Xpo.CreateXPObject<SalesLineItem>();

            sli.CreateDefaults();

            sli.Quantity = 22;

            Assert.IsTrue(sli.GetDefaultSchedule().Qty == 22);
        }
        
    }
}