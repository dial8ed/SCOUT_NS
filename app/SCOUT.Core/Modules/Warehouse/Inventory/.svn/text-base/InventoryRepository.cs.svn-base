using System.Collections.Generic;
using DevExpress.Data.Filtering;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    internal class InventoryRepository
    {
        internal static InventoryItem GetItemById(IUnitOfWork uow, string lotId)
        {
            GroupOperator criteria =
                new GroupOperator(new CriteriaOperator[]
                                      {
                                          new BinaryOperator("LotId", lotId),
                                          new BinaryOperator("Qty", 0, BinaryOperatorType.Greater)
                                      });
            return Repository
                .Get<InventoryItem>(uow)
                .ByCriteria(criteria);
        }


        internal static InventoryItem GetItemRecordById(IUnitOfWork uow, string lotId)
        {
            CriteriaOperator criteria = new BinaryOperator("LotId", lotId);
            return GetItemByCriteria(uow, criteria);
        }


        internal static InventoryItem GetItemBySN(IUnitOfWork uow, string sn)
        {
            BinaryOperator op1 = new BinaryOperator("SerialNumber", sn);
            BinaryOperator op2 = new BinaryOperator("Qty", 0 , BinaryOperatorType.Greater);
            GroupOperator criteria = new GroupOperator(op1,op2);

            return GetItemByCriteria(uow, criteria);
        }


        internal static InventoryItem GetItemByCriteria(IUnitOfWork uow, CriteriaOperator criteria)
        {
            return Repository
                .Get<InventoryItem>(uow)
                    .ByCriteria(criteria);
        }


        internal static SerializedUnit GetSerializedUnitBySN(string sn)
        {
            CriteriaOperator op1 = CriteriaOperator.Parse
                ("InitIdent = '" + sn + "' AND ReturnEndDate IS NULL ");

            return Repository
                .Get<SerializedUnit>(Scout.Core.Data.GetUnitOfWork() as IUnitOfWork)
                .ByCriteria(op1);
        }


        internal static SerializedUnit GetSerializedUnitById(IUnitOfWork uow, string lotId)
        {
            return Repository
                .Get<SerializedUnit>(uow)
                .ById(lotId);
        }


        internal static InventoryItem GetItemByLotIdOrSerialNumber(IUnitOfWork uow, string identifier)
       {           
           BinaryOperator op1 = new BinaryOperator("SerialNumber", identifier);
           BinaryOperator op2 = new BinaryOperator("LotId", identifier);           
           GroupOperator op3 = new GroupOperator(GroupOperatorType.Or, op1, op2);

           BinaryOperator op4 = new BinaryOperator("Qty", 0, BinaryOperatorType.Greater);
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And, op3, op4);

           return GetItemByCriteria(uow, criteria);
       }


        internal static SerializedUnit GetSerializedUnitByCriteria(IUnitOfWork uow, CriteriaOperator criteria)
        {
            return Repository
                .Get<SerializedUnit>(uow)
                .ByCriteria(criteria);
        }

        internal static NSLotIdSerial GetNSLotBySerialNumber(IUnitOfWork uow, string serialNumber)
        {
            BinaryOperator op = new BinaryOperator("SerialNumber", serialNumber);

            return Repository
                .Get<NSLotIdSerial>(uow)
                .ByCriteria(op);
            
        }

        internal static InventoryServiceProperties GetServicePropertiesForItem(IUnitOfWork uow, InventoryItem item)
        {
            BinaryOperator op = new BinaryOperator("Item", item);
            return Repository.Get<InventoryServiceProperties>(uow)
                .ByCriteria(op);
        }


        public static ICollection<InventoryCaptureProperties> GetAllCaptureUnitsByCriteriaString(IUnitOfWork uow, string criteria)
        {
            CriteriaOperator op1 = CriteriaOperator.Parse(criteria, null);
            return Repository
                    .GetList<InventoryCaptureProperties>(uow)
                    .ByCriteria(op1);            
        }
    }
}