using System.Collections.Generic;
using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Core.Modules;
using SCOUT.Core.Services;

namespace SCOUT.Tests.Core
{
    [TestFixture] 
    public class ModuleTests
    {
        [Test]
        public void can_register_and_get_a_service_from_registry()
        {
            ServiceRegistry registry = new ServiceRegistry();
            registry.Register<ITestInterface>(new TestInterface());
            Assert.IsNotNull(registry.Get<ITestInterface>());            
        }  

        [Test]
        public void all_default_modules_are_registered_when_scout_is_created()
        {
            Modules modules = Scout.Core.Modules;       
            Assert.IsNotNull(modules.Client);
            Assert.IsNotNull(modules.Shopfloor);
            Assert.IsNotNull(modules.Warehouse); 
        }

        [Test]
        public void can_get_all_services_from_modules()
        {
            Assert.IsNotNull(Scout.Core.Service<IInventoryService>());
        }

        [Test]
        public void scout_get_all_modules_returns_default_imodule_collection()
        {
            ICollection<IModule> modules = Scout.Core.Modules.AllModules();

            Assert.IsTrue(modules.Contains(Scout.Core.Modules.Shopfloor));
            Assert.IsTrue(modules.Contains(Scout.Core.Modules.Warehouse));
            Assert.IsTrue(modules.Contains(Scout.Core.Modules.Client));
        }

        [Test]
        public void core_default_module_provider_is_initialized_when_set()
        {
            Helpers.Core.Initialize();          
            Assert.IsNotNull(Scout.Core.DefaultModuleProvider);               
        }

        [Test]
        public void can_get_a_service_from_a_module()
        {
            IWarehouseModule module = Scout.Core.Modules.Warehouse;
            Assert.IsNotNull(module.GetService<IInventoryService>());
        }
    }

    public class TestInterface: ITestInterface
    {
        public void Test()
        {
            // Test            
        }
    }

    public interface  ITestInterface
    {
        void Test();
    }
}