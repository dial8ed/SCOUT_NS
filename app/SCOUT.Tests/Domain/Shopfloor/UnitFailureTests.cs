using System.Threading;
using NUnit.Framework;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain
{
    [TestFixture]
    public class UnitFailureTests
    {
        [SetUp]
        public void Setup()
        {            
            Helpers.Core.Initialize();
        }

        [Test]
        public void when_the_first_failure_is_added_to_the_collection_it_is_set_to_the_fp_error_code()
        {
            RouteStationProcess process = Xpo.CreateXPObject<RouteStationProcess>();
            InventoryItem item = Xpo.CreateXPObject<InventoryItem>();
            process.Item = item;

            ServiceCode serviceCode = Xpo.CreateXPObject<ServiceCode>();
            RouteStationFailure firstFailure;
            firstFailure = process.AddFailure(serviceCode, "test");
            Assert.That(firstFailure.IsFpErrorCode);            
        }

        [Test]
        public void the_fp_error_code_should_be_allowed_to_change_to_a_different_fail_code()
        {
            RouteStationProcess process = Xpo.CreateXPObject<RouteStationProcess>();
            InventoryItem item = Xpo.CreateXPObject<InventoryItem>();
            process.Item = item;

            ServiceCode firstCode = Xpo.CreateXPObject<ServiceCode>();
            RouteStationFailure firstFailure;
            firstFailure = process.AddFailure(firstCode, "first");

            Assert.That(firstFailure.IsFpErrorCode,"The first failure was not set to the fp error code!");

            ServiceCode secondCode = Xpo.CreateXPObject<ServiceCode>();
            RouteStationFailure shouldBeFpFailure;
            shouldBeFpFailure =  process.AddFailure(secondCode,"should_be_fp");

            process.ChangeFpErrorCodeOwner(shouldBeFpFailure);

            Assert.That(shouldBeFpFailure.IsFpErrorCode, "Changing of the fp error code did not succeed!");
            Assert.That(firstFailure.IsFpErrorCode == false, "The previous fp error code owner was not relieved!");

        }

        //[Test]
        public void when_the_fp_error_code_is_deleted_it_should_be_reset_to_the_first_fail_code()
        {
            RouteStationProcess process = Xpo.CreateXPObject<RouteStationProcess>();
            InventoryItem item = Xpo.CreateXPObject<InventoryItem>();
            process.Item = item;

            ServiceCode firstCode = Xpo.CreateXPObject<ServiceCode>();
            process.AddFailure(firstCode, "first");
            
            ServiceCode secondCode = Xpo.CreateXPObject<ServiceCode>();
            process.AddFailure(secondCode, "delete_me");

            //process.ChangeFpErrorCode(1);

            process.AllProcessFailures.Remove(process.Failures[1]);
                                    
            Assert.That(process.Failures[0].IsFpErrorCode);
            
        }
        
        [TearDown]
        public void TearDown()
        {
            Xpo.Destroy();
        }        
    }
}