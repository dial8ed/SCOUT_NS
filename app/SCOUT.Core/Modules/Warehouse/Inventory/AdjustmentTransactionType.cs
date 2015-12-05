using System.Collections.Generic;

namespace SCOUT.Core.Modules.Warehouse.Inventory
{
    public class AdjustmentTransactionType
    {        
        public AdjustmentTransactionType(string code, string description, string direction)
        {
            Code = code;
            Description = description;
            Direction = direction;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }

        public override string ToString()
        {
            return Code;
        }

        public static List<AdjustmentTransactionType> AsList()
        {          
            return new List<AdjustmentTransactionType>()
                       {
                           new AdjustmentTransactionType("CCADJIN", "Cycle count adjustment in", "IN"),
                           new AdjustmentTransactionType("PIADJIN", "Physical inventory adjustment in", "IN"),
                           new AdjustmentTransactionType("INVADJIN", "Inventory adjustment in", "IN"),
                           new AdjustmentTransactionType("WIPENGADJIN", "Wip engineering unit adjustment in", "IN"),
                           new AdjustmentTransactionType("WIPGOLDADJIN", "Wip gold unit adjustment in", "IN"),
                           new AdjustmentTransactionType("CCADJOUT", "Cycle count adjustment out", "OUT"),
                           new AdjustmentTransactionType("PIADJOUT", "Physical inventory adjustment out", "OUT"),
                           new AdjustmentTransactionType("INVADJOUT", "Inventory adjustment out", "OUT"),
                           new AdjustmentTransactionType("WIPENGADJOUT", "Wip engineering unit adjustment out", "OUT"),
                           new AdjustmentTransactionType("WIPGOLDADJOUT", "Wip gold unit adjustment out", "OUT"),
                           new AdjustmentTransactionType("SCRAPADJOUT", "Scrap adjustment out", "OUT"),
                           new AdjustmentTransactionType("SMEADJIN","SME parts adjustment in", "IN"),
                           new AdjustmentTransactionType("SMEADJOUT", "SME parts adjustment out", "OUT"),
                           new AdjustmentTransactionType("XIPTESTADJOUT", "XIP test adjustment out", "OUT"),
                           new AdjustmentTransactionType("XIPADJOUT","XIP parts adjustment out", "OUT"),
                           new AdjustmentTransactionType("XIPADJIN", "XIP parts adjustment in", "IN")
                       };            
        }
    }
}