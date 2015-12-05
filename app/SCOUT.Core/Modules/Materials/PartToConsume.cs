using SCOUT.Core.Data;

namespace SCOUT.Core.Modules.Materials
{
    public class PartToConsume
    {
        public PartToConsume(Part part, int qty, BomUsageAction usageAction)
        {
            Part = part;
            Qty = qty;
            UsageAction = usageAction;
        }

        public Part Part { get; set; }
        public int Qty { get; set; }
        public BomUsageAction UsageAction { get; set; }
       
    }
}