using NUnit.Framework;
using SCOUT.Core.Providers.Data;
using SCOUT.Tests.Domain;

namespace SCOUT.Tests.Data
{
    [TestFixture]
    public class RepositoryTests2
    {
        [Test]
        public void can_save_to_repository()
        {
            var repo = new XpoRepository(Xpo.UnitOfWork());
            var entity = repo.Create<XpoTestEntity>();

            entity.Name = "Test";
            entity.Type = "test";

            repo.Save();
          
            var repoItem = repo.Get<XpoTestEntity>(i => i.Name == "Test");
            Assert.IsNotNull(repoItem);
        }

        [Test]
        public void can_create_entity_if_not_found()
        {
            var repo = new XpoRepository(Xpo.UnitOfWork());
            var item = repo.GetAndCreateIfNotFound<XpoTestEntity>
                (i => i.Name == "ShouldntExist", d =>
                                            {
                                                d.Name = "New";
                                                d.Type = "XpoTestEntity";                                                
                                            });
           
            Assert.That(item != null && item.Name == "New");
        }


        [Test]
        public void can_return_default_entity_if_not_found()
        {
            var repo = new XpoRepository(Xpo.UnitOfWork());
            var item  = repo.GetAndDefaultIfNotFound<XpoTestEntity, NullXpoTestEntity>(x => x.Name == "ShouldntExist");

            Assert.That(item is NullXpoTestEntity);
        }
    }
}