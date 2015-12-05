using System;

namespace SCOUT.Core.Data
{
    public class ReceiptTransactionMapper : Core.IMapper<Receipt, Transaction>
    {
        public Transaction MapFrom(Receipt input)
        {
            Transaction transaction = input.Session.FindObject<Transaction>
                (new GroupOperatorMapper().MapFrom(new ReceiptTransactionFacts(input).Facts));
           
            if(transaction == null)
                    transaction = TransactionFactory.CreateTransaction(input.Session,"PURREC");            
            transaction.TransType = "PURREC";
            transaction.Item = input.Item;
            transaction.Part = input.Part;
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = input.ReceivedBy;
            transaction.ArrivalLocation = input.PurchaseOrder.RecDomain.ToString();
            transaction.Qty = input.Qty;

            return transaction;
        }
    }
}