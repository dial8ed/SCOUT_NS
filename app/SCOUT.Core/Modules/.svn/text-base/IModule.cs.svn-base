using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.Core.Modules
{
    public interface IModule
    {
        ServiceRegistry Services { get; }
        ModuleProvider Provider { get; }        
        T GetService<T>();
        void RegisterService<T>(T service);
        string Name { get; }
    }
}