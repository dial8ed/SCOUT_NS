namespace SCOUT.Core.Bus
{
    public interface IListener<T>
    {
        void Process(T message);
    }
}