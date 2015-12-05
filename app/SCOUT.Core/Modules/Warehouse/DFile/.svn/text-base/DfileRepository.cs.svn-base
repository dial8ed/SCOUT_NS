using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;

namespace SCOUT.Core.Data
{
    public class DfileRepository : ModuleService, IDfileRepository
    {
        public DfileRepository(IModule module)
            : base(module)
        {

        }

        public DfileItem GetUnResolvedItemBySerialNumber(IUnitOfWork uow, string serialNumber)
        {
            string criteria = 
                string.Format("[SerialNumber]='{0}' AND [Status]<>'{1}'", serialNumber, DfileStatus.Closed);
            
            return Repository
                    .Get<DfileItem>(uow)
                    .ByCriteria(criteria);
        }

        public ICollection<DfileItem> GetActiveDfileItemsByIncomingOrder(IUnitOfWork uow, int incomingOrderId)
        {            
            BinaryOperator op1 = new BinaryOperator("IncomingOrderId", incomingOrderId);
            BinaryOperator op2 = new BinaryOperator("Status", DfileStatus.Closed, BinaryOperatorType.NotEqual);
            GroupOperator criteria = new GroupOperator(op1,op2);
            return Repository
                    .GetList<DfileItem>(uow)
                    .ByCriteria(criteria);            
        }

        public ICollection<DfileItem> GetOpenDfileItemsByShopfloorline(IUnitOfWork uow, Shopfloorline shopfloorline)
        {
           
            BinaryOperator op1 = new BinaryOperator("ShopfloorlineId", shopfloorline.Id);
            BinaryOperator op2 = new BinaryOperator("Status", DfileStatus.Open);
            GroupOperator criteria = new GroupOperator(op1,op2);

            return Repository
                       .GetList<DfileItem>(uow)
                       .ByCriteria(criteria);
        }
       
        public ICollection<DfileItem> GetDfileItemsByCritieria(IUnitOfWork uow, string criteria)
        {
            try
            {                            
                return Repository
                    .GetList<DfileItem>(uow)
                    .ByCriteria(criteria);

            }
            catch (Exception ex)
            {
                UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
             }

            return null;            
        }

        public ICollection<DfileItem> GetResolvedItemsByShopfloorline(IUnitOfWork uow, Shopfloorline shopfloorline)
        {
            BinaryOperator op1 = new BinaryOperator("ShopfloorlineId", shopfloorline.Id);
            BinaryOperator op2 = new BinaryOperator("Status", DfileStatus.Resolved);
            GroupOperator criteria = new GroupOperator(op1,op2);

            return Repository
                    .GetList<DfileItem>(uow)
                    .ByCriteria(criteria);            
        }

        public DfileItem GetResolvedItemBySerialNumber(IUnitOfWork uow, string serialNumber)
        {
            string criteria = string.Format("[SerialNumber]='{0}' AND [Status]='{1}'", serialNumber, DfileStatus.Resolved);

            return Repository
                    .Get<DfileItem>(uow)
                    .ByCriteria(criteria);
        }
    }
}