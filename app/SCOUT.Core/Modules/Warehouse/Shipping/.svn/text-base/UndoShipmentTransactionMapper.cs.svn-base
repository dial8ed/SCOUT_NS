using System;

namespace SCOUT.Core.Data
{
    public class UndoShipmentTransactionMapper : Core.IMapper<Shipment, Transaction>
    {
        public Transaction MapFrom(Shipment input)
        {
            Transaction transaction = Scout.Core.Data.CreateEntity<Transaction>(input.Session);
            transaction.TransType = "UNDOSHIP";
            transaction.Item = input.Item;
            transaction.Part = input.Part;
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = Security.UserSecurity.CurrentUser.Login;
            transaction.DepartLocation = "";
            transaction.ArrivalLocation = ""; 
            transaction.Qty = input.Qty;
            return transaction;
        }
    }
}