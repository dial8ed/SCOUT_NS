using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace SCOUT.Core.Data
{
    internal class TransactionRepository
    {
        internal static ICollection<TransactionType> GetTransactionTypes()
        {
            return Repository
                .GetList<TransactionType>(Scout.Core.Data.GetUnitOfWork() as IUnitOfWork)
                .All();
        }

        internal static TransactionSpecification GetTransactionSpecificationFor(TransactionType type, Shopfloorline sfl)
        {
            switch(type.TransCode)
            {
                case "PUTAWAY":
                    return new PutAwayTransactionSpecification(sfl, type);
                case "DOMAINTRANS":
                    return new DomainTransactionSpecification(sfl, type);
                case "SFLTRANS":
                    return new ShopfloorlineTransactionSpecification(sfl, type);
                case "TOTEPUTAWAY":
                    break;
                case "TOTETRANS":
                    break;
            }

            return null;
            
        }

        internal static ICollection<Transaction> GetTransactionsByRef(IUnitOfWork session, string num)
        {
            return Repository
                .GetList<Transaction>(session)
                .ByCriteria(new BinaryOperator("TransRef", num));
        }
    }
}