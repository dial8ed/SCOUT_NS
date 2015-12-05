using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class TransactionService : ModuleService, ITransactionService
    {
        public TransactionService(IModule module) : base(module)
        {
        }

        public Transaction CreateTransaction(string transType, InventoryItem item, string departStation,
                                                    string arrivalStation, string comments, string refNum)
        {
            Transaction transaction = Scout.Core.Data.CreateEntity<Transaction>(item.Session);
            transaction.TransDate = DateTime.Now;
            transaction.TransBy = Security.UserSecurity.CurrentUser.Login;           
            transaction.TransType = transType;
            transaction.ArrivalLocation = arrivalStation;
            transaction.DepartLocation = departStation;
            transaction.Item = item;
            transaction.Part = item.Part;
            transaction.Qty = item.Qty;
            transaction.Comments = comments;
            transaction.TransRef = refNum;
            transaction.Program = item.ShopfloorProgram;

            return transaction;
        }


        public ICollection<Transaction> GetTransactionsByRef(IUnitOfWork session, string refNum)
        {
            return TransactionRepository.GetTransactionsByRef(session, refNum);
        }

        public ICollection<TransactionType> GetTransactionTypes()
        {
            return TransactionRepository.GetTransactionTypes();
        }

        public TransactionSpecification GetTransactionSpecificationFor(TransactionType type, Shopfloorline sfl)
        {
            return TransactionRepository.GetTransactionSpecificationFor(type, sfl);
        }

        public Transaction CreateTransactionFromSpecification(TransactionSpecification spec)
        {
            return CreateTransaction(spec.TransactionType.TransCode,
                                     spec.Item,
                                     spec.SourceArea.FullLocation,
                                     spec.DestinationArea.FullLocation,
                                     spec.Comments,
                                     spec.TransactionReference);
        }

        public bool SaveTransaction(TransactionSpecification specification)
        {
            // Ask the spec to update the inventory with its changes.
            // TODO: SMELLS FUNNY!
            specification.UpdateItem();

            // Create the transaction to be persisted
            Transaction trans = CreateTransactionFromSpecification(specification);

            try
            {
                Scout.Core.Data.Save(specification.Item.Session);
                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
                return false;
            }
        }
    }
}