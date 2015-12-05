using System.Collections.Generic;

namespace SCOUT.Core.Providers
{
    public interface IContainerProvider
    {
        T GetInstance<T>();
        IEnumerable<T> GetAllInstances<T>();
    }
}