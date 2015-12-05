using System;
using SCOUT.Core.Data;

namespace SCOUT.Core.Modules.Materials.Repository
{
    public class MaterialsRepository : IMaterialsRepository
    {
        public MaterialConsumableItem GetConsumableItem(IUnitOfWork uow, int sflId, int partId)
        {
            return Scout.Core.Data.GetRepository(uow)
                .Get<MaterialConsumableItem>
                    (p => p.Shopfloorline.Id == sflId && p.Part.Id == partId);
            
        }
    }
}