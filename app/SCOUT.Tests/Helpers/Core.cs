using SCOUT.Core.Data;

namespace SCOUT.Tests.Helpers
{
    public class Core
    {
        public static void Initialize()
        {
            Scout.Core.DefaultModuleProvider = new ModuleProvider()
            {
                Data = new TestDataProvider(),
                UserInteraction = new TestUserInteractionProvider()
            };
        }
    }
}