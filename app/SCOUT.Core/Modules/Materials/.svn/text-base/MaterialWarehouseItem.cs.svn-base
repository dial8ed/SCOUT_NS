using System;

namespace SCOUT.Core.Data
{
    public partial class MaterialWarehouseItem
    {
        public void IncreaseQty(int qty)
        {
            Qty += qty;
        }

        public void DecreaseQty(int qty)
        {
            if(Qty - qty < 0)
                throw new NotSupportedException("Cannot decrease qty below 0");

            Qty -= qty;
        }        
    }
}