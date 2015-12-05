using System;
using System.Collections.Generic;
using StructureMap;

namespace SCOUT.Core.Providers.Container
{
    public class ContainerProvider : IContainerProvider
    {
        public T GetInstance<T>()
        {
            return ObjectFactory.GetInstance<T>();            
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            return ObjectFactory.GetAllInstances<T>();
        }

    }
}