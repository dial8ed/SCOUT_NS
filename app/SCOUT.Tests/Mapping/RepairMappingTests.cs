using DevExpress.Xpo;
using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Tests.Domain;
using SCOUT.Tests.Domain.Fakes;

namespace SCOUT.Tests.Mapping
{
    [TestFixture]
    public class RepairMappingTests
    {
        private UnitOfWork m_uow;

        [SetUp]
        public void SetUp()
        {
            m_uow = Xpo.UnitOfWork();
        }

        [Test]
        public void when_mapping_replacement_model_to_component()
        {
            var repair = new RouteStationRepair(m_uow);
            var model = new ReplacementComponentFacts(repair);
            model.Component = new FakeServiceCommodity(m_uow);
            model.PartIn = new FakePart(m_uow);
            model.PartOut = new FakePart(m_uow);

            model.SerialNumberIn = "sn in";
            model.SerialNumberOut = "sn out";
            model.UnitOfWork = m_uow as IUnitOfWork;

            var component  =  Scout.Core.Mapping.Map<ReplacementComponentFacts, RepairComponent>(model);

            Assert.IsInstanceOf(typeof(FakePart), component.PartIn);
            Assert.That(component.SerialNumberIn == "sn in");
            Assert.That(component.Session == m_uow);

        }       
 
    }
}