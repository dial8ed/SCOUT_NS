using SCOUT.Core.Data;

namespace SCOUT.Core.Modules.Materials.Repository
{
    public interface IMaterialsRepository
    {
        MaterialConsumableItem GetConsumableItem(IUnitOfWork uow, int sflId, int partId);


    }
}