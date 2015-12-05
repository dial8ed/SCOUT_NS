using SCOUT.Core.Data;

namespace SCOUT.Core.Providers.Data
{
    public static class UnitOfWorkExtensions
    {
        public static IRepository AsRepository(this IUnitOfWork uow)
        {
            return new XpoRepository(uow);
        }
        
    }
}