using System;

namespace SCOUT.Core.Bus
{
    public interface IEventBus
    {
        void Register<T>(Action<T> handler);
        void Raise<T>(T message);
    }
}