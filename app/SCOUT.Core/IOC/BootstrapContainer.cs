using SCOUT.Core.IOC.Registries;
using StructureMap;

namespace SCOUT.Core.IOC
{
    public class BootstrapContainer
    {     
        public static void Initialize()
        {
            ObjectFactory.Initialize(x =>
                                              {
                                                  x.AddRegistry<ScriptRegistry>();
                                                  x.AddRegistry<MapperRegistry>();
                                              }
                );
        }        
    }
}