using SCOUT.Core.Messaging;

namespace SCOUT.Core
{
    public interface IActionSpecification<T>
    {
        bool IsSatisfiedBy(T t);
        UserMessage Message{ get; }
        void ExecuteAction();
    }
}