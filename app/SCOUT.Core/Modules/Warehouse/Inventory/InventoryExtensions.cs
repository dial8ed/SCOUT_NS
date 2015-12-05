using System.Collections.Generic;

namespace SCOUT.Core.Modules.Warehouse.Inventory
{
    public static class InventoryExtensions
    {
        public static List<AdjustmentTransactionType> PrefixCodesWith(this List<AdjustmentTransactionType> list, string prefix)
        {
            foreach (var sourceType in list)
            {
                sourceType.Code = prefix + sourceType.Code;
            }
            return list;
        }        
    }
}