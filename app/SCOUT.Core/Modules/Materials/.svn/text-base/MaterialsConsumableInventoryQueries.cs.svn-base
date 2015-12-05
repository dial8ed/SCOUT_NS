using System;
using System.Linq.Expressions;
using SCOUT.Core.Data;

namespace SCOUT.Core.Modules.Materials
{
    public partial class MaterialsConsumableInventory
    {
        public static Expression<Func<MaterialConsumableItem,bool>> DefaultSearch(Part part, Shopfloorline sfl)
        {
            return Expression.Lambda<Func<MaterialConsumableItem,bool>>
                (Expression.AndAlso(ByPart(part).Body, ByShopfloorline(sfl).Body));                      
        }

        public static Expression<Func<MaterialConsumableItem,bool>> ByShopfloorline(Shopfloorline sfl)
        {
            return (i) => i.Shopfloorline.Id == sfl.Id;
        }

        public static Expression<Func<MaterialConsumableItem,bool>> ByPart(Part part)
        {
            return (i) => i.Part.Id == part.Id;
        }
        
    }
}