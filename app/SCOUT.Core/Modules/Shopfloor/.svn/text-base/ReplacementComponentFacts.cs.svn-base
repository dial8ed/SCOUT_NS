namespace SCOUT.Core.Data
{
    public class ReplacementComponentFacts
    {        
        public ReplacementComponentFacts()
        {
            
        }

        public ReplacementComponentFacts(RouteStationRepair repair)
        {
            Repair = repair;
            UnitOfWork = repair.Session;
        }

        public virtual ServiceCommodityComponent Component { get; set; }

        public RouteStationRepair Repair { get; set; }

        public virtual Part PartIn { get; set; }

        public Part PartOut { get; set; }

        public string SerialNumberIn { get; set; }

        public string SerialNumberOut { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        public Shopfloorline Shopfloorline { get; set; }

        public int ConsumptionId { get; set; }

        
    }
}