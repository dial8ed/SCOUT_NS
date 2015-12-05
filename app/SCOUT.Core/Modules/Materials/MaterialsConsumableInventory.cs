using System;
using System.Linq.Expressions;
using SCOUT.Core.Data;
using SCOUT.Core.Utils;
using IRepository = SCOUT.Core.Providers.Data.IRepository;

namespace SCOUT.Core.Modules.Materials
{
    public partial class MaterialsConsumableInventory
    {
        private IRepository m_repository;

        public MaterialsConsumableInventory(IRepository repository)
        {
            m_repository = repository;
        }

        public MaterialConsumableItem IncreaseItemQty(Part part, Shopfloorline sfl, int qty)
        {            
            var item = m_repository.GetAndCreateIfNotFound(DefaultSearchExpression(part, sfl),
                                                   DefaultCreateMapping(part, sfl, 0));
            item.IncreaseQty(qty);

            return item;
        }   


        public MaterialConsumableItem DecreaseItemQty(Part part, Shopfloorline sfl, int qty)
        {
            MaterialConsumableItem item = null;
            Expression<Func<MaterialConsumableItem, bool>> criteria =
                mci => mci.Part.Id == part.Id && mci.Shopfloorline.Id == sfl.Id && mci.Qty > 0;

            ExecutionHelpers.ThrowIfNull(
                   () => item = m_repository.Get(criteria),
                    "Consumable item not found" 
                );

            item.DecreaseQty(qty);

            return item;
        }
     

        public static Action<MaterialConsumableItem> DefaultCreateMapping(Part part, Shopfloorline sfl, int qty)
        {
            return (i) => { i.Part = part;
                              i.Qty = qty;
                              i.Shopfloorline = sfl;
            };
        }

        public static Expression<Func<MaterialConsumableItem, bool>> DefaultSearchExpression(Part part, Shopfloorline sfl)
        {
            return (i) => i.Part.Id == part.Id && i.Shopfloorline.Id == sfl.Id;
        }

        
    }
}