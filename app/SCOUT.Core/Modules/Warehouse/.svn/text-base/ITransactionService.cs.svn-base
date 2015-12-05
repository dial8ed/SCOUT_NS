using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface ITransactionService
    {
        Transaction CreateTransaction(string transType, InventoryItem item, string departStation,
                                      string arrivalStation, string comments, string refNum);

        ICollection<Transaction> GetTransactionsByRef(IUnitOfWork session, string refNum);
        ICollection<TransactionType> GetTransactionTypes();
        TransactionSpecification GetTransactionSpecificationFor(TransactionType type, Shopfloorline sfl);
        Transaction CreateTransactionFromSpecification(TransactionSpecification spec);
        bool SaveTransaction(TransactionSpecification specification);
    }
}