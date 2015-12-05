using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using SCOUT.Core.Modules.Materials;

namespace SCOUT.Core.Data
{
    public class MaterialRepository
    {
        public static MaterialWarehouseItem GetItemByDomain(Part part, Domain domain)
        {
            //var op1 = new BinaryOperator("Part", part);
            //var op2 = new BinaryOperator("Domain", domain);
            //var op3 = new NullOperator("RackLocation");
            //var criteria = new GroupOperator(op1, op2, op3);

            return Repository
                .Find<MaterialWarehouseItem>(part.Session)
                .Single(i => i.Part.Id == part.Id 
                        && i.Domain.Id == domain.Id 
                        && i.RackLocation == null);

        }

        internal static MaterialReceiptPartSummary GetReceiveSummaryForPart
            (MaterialPurchaseOrder order, Part part)
        {
            var op1 = new BinaryOperator("MaterialPurchaseOrder", order);
            var op2 = new BinaryOperator("Part", part);
            var criteria = new GroupOperator(op1, op2);

            return Repository
                .Get<MaterialReceiptPartSummary>(part.Session)
                .ByCriteria(criteria);
        }

        public static int GetReceiveQtyForPart(MaterialPurchaseOrder order, Part part)
        {
            MaterialReceiptPartSummary summary;

            summary = GetReceiveSummaryForPart(order, part);

            if (summary == null)
                return 0;
            else
                return summary.ReceiveQty;
        }

        internal static ICollection<MaterialWarehouseItem> GetIssuableItemsByPart(Part part)
        {
            var op1 = new BinaryOperator("Part", part);
            var op2 = new NotOperator(new NullOperator("RackLocation"));
            var op3 = new BinaryOperator("Qty", 0, BinaryOperatorType.Greater);
            var criteria = new GroupOperator(op1, op2, op3);

            return Repository
                .GetList<MaterialWarehouseItem>(part.Session)
                .ByCriteria(criteria);
        }

        internal static MaterialWarehouseItem GetRacklocationItemByPart(Part part, string rackLocation)
        {
            var op1 = new BinaryOperator("Part", part);
            var op2 = new BinaryOperator("RackLocation", rackLocation);
            var criteria = new GroupOperator(op1, op2);

            return Repository
                .Get<MaterialWarehouseItem>(part.Session)
                .ByCriteria(criteria);
        }

        internal static ICollection<MaterialWarehouseItem> GetItemsNeedingPutAway(Part part)
        {
            var op1 = new BinaryOperator("Part", part);
            var op2 = new NullOperator("RackLocation");
            var op3 = new BinaryOperator("Qty", 0, BinaryOperatorType.Greater);
            var criteria = new GroupOperator(op1, op2, op3);

            return Repository
                .GetList<MaterialWarehouseItem>(part.Session)
                .ByCriteria(criteria);
        }

        public static MaterialConsumableItem GetConsumableItemByPart(IUnitOfWork uow, Part part, Shopfloorline shopfloorline)
        {
            var op1 = new BinaryOperator("Part", part);
            var op2 = new BinaryOperator("Shopfloorline", shopfloorline);
            var criteria = new GroupOperator(op1, op2);

            return Repository
                .Get<MaterialConsumableItem>(uow)
                .ByCriteria(criteria);
        }

        internal static ICollection<MaterialConsumableItem> GetConsumableItemsByPart(Part part)
        {
            var op1 = new BinaryOperator("Part", part);
            var op2 = new BinaryOperator("Qty", 0, BinaryOperatorType.Greater);
            var criteria = new GroupOperator(op1, op2);

            return Repository
                .GetList<MaterialConsumableItem>(part.Session)
                .ByCriteria(criteria);
        }

        public static ICollection<MaterialWarehouseItem> GetWarehouseItemsByPart(Part part)
        {
            var op1 = new BinaryOperator("Part", part);
            var op2 = new BinaryOperator("Qty", 0, BinaryOperatorType.Greater);
            var criteria = new GroupOperator(op1, op2);

            return Repository
                .GetList<MaterialWarehouseItem>(part.Session)
                .ByCriteria(criteria);
        }

        public static ICollection<BomConfiguration> GetStationBomConfigurations(IUnitOfWork uow,
                                                                                 Shopfloorline shopfloorline)
        {
            BinaryOperator op1 = new BinaryOperator("Shopfloorline", shopfloorline);
            return Repository
                .GetList<BomConfiguration>(uow)
                .ByCriteria(op1);
        }

        public static ICollection<Transaction> GetMaterialsConsumed(IUnitOfWork uow, string lotId)
        {
            var repo = Scout.Core.Data.GetRepository(uow);
            var trans = repo.Find<Transaction>().Where(t => t.ConsumedInLotId == lotId);
            var components = repo.Find<RepairComponent>().Where(r => r.Repair.Item.LotId == lotId);

            var query = from t in trans
                        join c in components on t.TransId equals c.ConsumptionId into tc
                        where tc.Count() > 0
                        select t;

            return query.ToList();

        }
       
    }
}