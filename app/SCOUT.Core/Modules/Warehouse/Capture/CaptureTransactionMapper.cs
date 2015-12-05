using System;

namespace SCOUT.Core.Data
{
    public class CaptureTransactionMapper : IMapper<InventoryHold, Transaction> 
    {
        public Transaction MapFrom(InventoryHold input)
        {
            Transaction transaction = Scout.Core.Data.CreateEntity<Transaction>(input.Session);
            transaction.TransType = "CAPTURE";
            transaction.Item = input.Item;
            transaction.Part = input.Item.Part;
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = Security.UserSecurity.CurrentUser.Login;
            transaction.ArrivalLocation = input.Item.Domain.FullLocation;
            transaction.DepartLocation = input.Item.PurchaseOrder.RecDomain.FullLocation;
            transaction.Qty = input.Item.Qty;
            return transaction;
        }
    }
}