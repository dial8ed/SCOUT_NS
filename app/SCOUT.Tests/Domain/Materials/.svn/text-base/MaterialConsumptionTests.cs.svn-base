using System.Data;
using System.Linq;
using Moq;
using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Core.Modules.Shopfloor;
using SCOUT.Core.Providers.Data;
using IRepository = SCOUT.Core.Providers.Data.IRepository;

namespace SCOUT.Tests.Domain.Materials
{
    [TestFixture]
    public class MaterialConsumptionTests
    {
        private IUnitOfWork m_unitOfWork;
        private IRepository m_repository;

        [SetUp]
        public void Setup()
        {
            Helpers.Core.Initialize();
        }


        //[Test]
        public void test()
        {
            var part = Xpo.CreateXPObject<Fakes.FakePart>();
            var consumableItem = Xpo.CreateXPObject<MaterialConsumableItem>();
            var sfl = Xpo.CreateXPObject<Shopfloorline>();
            consumableItem.Part = part;
            consumableItem.Qty = 10;
            consumableItem.Shopfloorline = sfl;

            m_unitOfWork = Xpo.UnitOfWork();
            m_repository = new XpoRepository(m_unitOfWork);
            m_repository.Create<MaterialConsumableItem>();

            m_repository.Save();

            var inventory = new ServiceMaterialsInventoryController(m_unitOfWork,m_repository);
            var transId = inventory.Consume("FAKE", 1, 1, "Repair", "");

            var item = m_repository.Find<MaterialConsumableItem>().FirstOrDefault(mci => mci.Part == part);
            Assert.That(item.Qty == 9);

        }

       [Test]
       public void when_consuming_a_part_that_does_not_exist_in_consumable_inventory()
       {           
           var uowMock = new Mock<IUnitOfWork>();
           var repoMock = new Mock<IRepository>();

           var inventory = new ServiceMaterialsInventoryController(uowMock.Object, repoMock.Object);
           Assert.IsTrue(inventory.Consume("INVALIDPN", 0, 0, "Repair", "") == default(int));

       }        

        [TearDown]
        public void teardown()
        {
            Xpo.Destroy();
        }
    }
}