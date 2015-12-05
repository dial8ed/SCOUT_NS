using System;

namespace SCOUT.Core.Data
{
    public partial class InventoryItem
    {
        public void Ship(Shipment shipment)
        {
            if (SerializedUnit != null)
            {
                SerializedUnit.EndIdent = SerialNumber;
                SerializedUnit.ReturnEndDate = shipment.ShipDate;
            }

            Qty -= shipment.Qty;

        }        
    }
}