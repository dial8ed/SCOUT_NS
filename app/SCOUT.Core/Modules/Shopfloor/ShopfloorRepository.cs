using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    public static class ShopfloorRepository
    {
        public static IEnumerable<IActionSpecification<RouteStationProcess>> 
            GetShopfloorConditions(RouteStationProcess process)
        {            
            List<IActionSpecification<RouteStationProcess>> conditions =
                new List<IActionSpecification<RouteStationProcess>>();

            if(process.ServiceRoute.Shopfloorline.Label == "XIP PRINTERS")
            {
                conditions.Add(new ExceedsPageCountCondition());       
            }

            return conditions;
        }        
    }
}