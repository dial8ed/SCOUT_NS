using SCOUT.Core.Data;

namespace SCOUT.Core.Modules.Materials
{
    public class RepairPartConsumed
    {
        public RouteStationRepair Repair { get; set; }
        public Transaction Transaction { get; set; }

    }
}