using System;

namespace SCOUT.Core.Data
{
    public partial class MaterialConsumableItem
    {

        public void IncreaseQty(int qty)
        {
            Qty += qty;
        }

        public void DecreaseQty(int qty)
        {
            if(Qty - qty <0)
                throw new NotSupportedException(Part.PartNumber + " cannot be consumed due to insufficient qty");
            Qty -= qty;

        }
        
    }
}