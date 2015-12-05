using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    public class TransactionFactory
    {        
        public static Transaction CreateTransaction(IUnitOfWork uow,string type)
        {
            switch (type)
            {
                case "STATIONTRANS":
                    return StationTransfer(uow);
                case "ROUTETRANS":
                    return RouteTransfer(uow);
                case "PNCHNG":
                    return PartChangeTransaction(uow);
            }

            return BaseTransaction(uow);
        }

        private static Transaction PartChangeTransaction(IUnitOfWork uow)
        {
            Transaction trans = BaseTransaction(uow);
            trans.TransType = "PNCHNG";
            return trans;
        }

        private static Transaction StationTransfer(IUnitOfWork uow)
        {
            Transaction trans = BaseTransaction(uow);
            trans.TransType = "STATIONTRANS";
            return trans;   
        }

        private static Transaction RouteTransfer(IUnitOfWork uow)
        {
            Transaction trans = BaseTransaction(uow);
            trans.TransType = "ROUTETRANS";
            return trans;
        }

        private static Transaction BaseTransaction(IUnitOfWork uow)
        {
            Transaction transaction = Scout.Core.Data.CreateEntity<Transaction>(uow);          
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = Security.UserSecurity.CurrentUser.Login;                       
            return transaction;
        }
    }
}