using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Core.Modules.Materials;
using SCOUT.Core.Providers.Data;
using SCOUT.Tests.Domain.Fakes;

namespace SCOUT.Tests.Domain.Materials
{
    [TestFixture]
    public class MaterialsWarehouseTests
    {
        private IUnitOfWork m_unitOfWork;

        [SetUp]
        public void setup()
        {
            m_unitOfWork = Xpo.UnitOfWork();
        }


        [Test]
        public void can_increase_warehouse_items()
        {
            var repo = new XpoRepository(m_unitOfWork);
            var part = repo.Create<FakePart>();     
            var domain = repo.Create<FakeDomain>();                  
            var warehouse = new MaterialsWarehouseInventory(repo);          
            
            warehouse.IncreaseItemQuantity(part, domain, null, 5);
            
            repo.Save();

            var item = repo.Get<MaterialWarehouseItem>(i => i.Part.Id == 1);
            Assert.That(item.Qty == 5);
        }


        [TearDown]
        public void teardown()
        {
            Xpo.Destroy();
        }

        //[Test]
        public void can_decrease_warehouse_items()
        {
            

        }
        
    }
}