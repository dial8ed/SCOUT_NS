using System;
using System.Linq;

namespace SCOUT.Core.Data
{
    internal class ScheduledShippingOpenQtyManager : IShippingOpenQtyManager
    {
        public int GetOpenQty(SalesLineItem lineItem)
        {
            var openScheduled = lineItem.Schedules.Where(s => DateTime.Compare(s.ScheduledDate, DateTime.Now) <= 0)
                .Sum(s => s.Qty);
                           
            return openScheduled - lineItem.ProcessedQty;
            
        }
    }
}