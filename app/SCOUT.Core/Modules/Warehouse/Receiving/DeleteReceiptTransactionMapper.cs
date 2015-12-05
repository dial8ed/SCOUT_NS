using System;

namespace SCOUT.Core.Data
{
    public class DeletedReceiptTransactionMapper : IMapper<Receipt,Transaction>
    {
        public Transaction MapFrom(Receipt input)
        {
            Transaction transaction = Scout.Core.Data.CreateEntity<Transaction>(input.Session);
            transaction.TransType = "DELREC";
            transaction.Item = input.Item;
            transaction.Part = input.Part;
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = Security.UserSecurity.CurrentUser.Login;
            transaction.ArrivalLocation = "";
            transaction.DepartLocation = input.PurchaseOrder.RecDomain.FullLocation;
            transaction.Qty = input.Qty;
            return transaction;
        }
    }
}