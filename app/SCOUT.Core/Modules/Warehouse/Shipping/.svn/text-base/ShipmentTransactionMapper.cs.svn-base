using System;

namespace SCOUT.Core.Data
{
    public class ShipmentTransactionMapper : Core.IMapper<Shipment, Transaction>
    {
        public Transaction MapFrom(Shipment input)
        {
            Transaction transaction = Scout.Core.Data.CreateEntity<Transaction>(input.Session);
            transaction.TransType = "SALESTK";
            transaction.Item = input.Item;
            transaction.Part = input.Part;
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = input.ShippedBy;
            transaction.DepartLocation = input.DepartureDomain.FullLocation;
            transaction.ArrivalLocation = "";
            transaction.Qty = input.Qty;

            return transaction;
        }
    }
}