using System;
using NUnit.Framework;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain
{
    [TestFixture]
    public class ShopfloorConditionControllerTests
    {

        [Test]
        public void can_add_condition()
        {
            ShopfloorConditionController controller = new ShopfloorConditionController("");
            controller.AddCondition("RR90");
            controller.AddCondition("SCRAP");
            Console.WriteLine(controller.ToString());
            Assert.IsTrue(controller.ToString() == "RR90,SCRAP");
        }

        [Test]
        public void array_is_initialized_after_construction()
        {
            ShopfloorConditionController  controller = new ShopfloorConditionController("RR90,SCRAP");
            Console.WriteLine(controller.ToString());
            Assert.IsTrue(controller.ToString() == "RR90,SCRAP");            
        }

        [Test]
        public void can_remove_condition()
        {
            ShopfloorConditionController controller = new ShopfloorConditionController("RR90,SCRAP");
            controller.RemoveCondition("RR90");
            Console.WriteLine(controller.ToString());
            Assert.IsTrue(controller.ToString() == "SCRAP");
        }        

        [Test]
        public void conditions_contains_returns_true()
        {
            ShopfloorConditionController controller = new ShopfloorConditionController("RR90,SCRAP");
            
            Console.WriteLine(controller.ToString());

            Assert.IsTrue(controller.ContainsCondition("RR90"));
        }
    }
}