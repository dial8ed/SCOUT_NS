using System;
using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Tests.Domain;

namespace SCOUT.Tests.Data
{
    [TestFixture]
    public class RepositoryTests
    {

        [Test]
        public void can_save_to_repository()
        {
            XpoTestEntity entity = Xpo.CreateXPObject<XpoTestEntity>();
                
            entity.Name = "Test";
            entity.Type = "Test";

            IUnitOfWork uow = entity.Session;
            uow.Commit();

            XpoTestEntity persistedEntity =
                uow.FindObject<XpoTestEntity>("Name='Test'");

            Assert.IsNotNull(persistedEntity);                    
        }   
  
        [Test]
        public void can_delete_from_repository()
        {
            XpoTestEntity entity = Xpo.CreateXPObject<XpoTestEntity>();
            entity.Name = "Test";
            entity.Type = "Test";

            IUnitOfWork uow = entity.Session;
            uow.Commit();

            XpoTestEntity persistedEntity = uow.FindObject<XpoTestEntity>("Name='Test'");

            if (persistedEntity == null)
                throw new NullReferenceException("XpoTestEntity has not been persisted to the in memory database.");

            uow.Delete(persistedEntity, true);

            XpoTestEntity deletedEntity = uow.FindObject<XpoTestEntity>("Name='Test'");                                      
            Assert.IsNull(deletedEntity);
        }

        [Test]
        public void can_postpone_delete_until_batch_is_complete()
        {
            // Create test record
            XpoTestEntity entity = Xpo.CreateXPObject<XpoTestEntity>();
            entity.Name = "Test";
            entity.Type = "Test";

            IUnitOfWork uow = entity.Session;
            uow.Commit();

            // Get test record
            XpoTestEntity persistedEntity = uow.FindObject<XpoTestEntity>("Name='Test'");

            // Postpone Delete
            uow.Delete(persistedEntity, false);

            // Persist
            uow.Commit();

            XpoTestEntity deletedEntity = uow.FindObject<XpoTestEntity>("Name='Test'");
            Assert.IsNull(deletedEntity);
            
        }
   
        [TearDown]
        public void TearDown()
        {
            Xpo.Destroy();   
        }
    }
}