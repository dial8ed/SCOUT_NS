using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;

namespace SCOUT.Core.Data
{
    public class OrderRepository
    {
        internal static PurchaseLineItem GetPurchaseLineItemFor(PurchaseOrder order, Part part)
        {            
            BinaryOperator op1 = new BinaryOperator("PurchaseOrder", order);
            BinaryOperator op2 = new BinaryOperator("Part", part);

            GroupOperator critiera = new GroupOperator(op1, op2);

            return Repository
                .Get<PurchaseLineItem>(order.Session)
                .ByCriteria(critiera);
        }

        internal static ReceivingPartSummary GetReceivingPartSummary(Part part, PurchaseOrder order)
        {            
            BinaryOperator op1 = new BinaryOperator("Part", part);
            BinaryOperator op2 = new BinaryOperator("PurchaseOrder", order);
      
            GroupOperator op = new GroupOperator(op1,op2);

            return Repository
                .Get<ReceivingPartSummary>(order.Session)
                .ByCriteria(op);   
        }

        internal static ReceivingLineSummary GetReceivingLineSummary(PurchaseLineItem lineItem)
        {            
            BinaryOperator op = new BinaryOperator("LineItem", lineItem);

            return Repository
                .Get<ReceivingLineSummary>(lineItem.Session)
                .ByCriteria(op);
        }

        internal static ShippingPartSummary GetShippingSummaryForLine(Part part, SalesOrder order)
        {            
            BinaryOperator op1 = new BinaryOperator("Part", part);
            BinaryOperator op2 = new BinaryOperator("SalesOrder", order);

            GroupOperator op = new GroupOperator(op1, op2);

            return Repository
                .Get<ShippingPartSummary>(order.Session)
                .ByCriteria(op);
        }

        internal static ShippingLineSummary GetShippingSummaryForLine(SalesLineItem lineItem)
        {            
            BinaryOperator op = new BinaryOperator("LineItem", lineItem);

            return Repository
                .Get<ShippingLineSummary>(lineItem.Session)
                .ByCriteria(op);
        }

        internal static ICollection<Packlist> GetPacklistsForSalesOrder(IUnitOfWork uow, SalesOrder order)
        {
            BinaryOperator criteria = new BinaryOperator("SalesOrder", order);

            return Repository
                .GetList<Packlist>(uow)
                .ByCriteria(criteria);
        }

        internal static T GetPreAlertItem<T>(PurchaseOrder order, string serialNumber)
        {
            BinaryOperator op1 = new BinaryOperator("SerialNumber", serialNumber);                
            BinaryOperator op2 = new BinaryOperator("PurchaseOrder", order);
            GroupOperator criteria = new GroupOperator(op1,op2);

            return Repository
                .Get<T>(order.Session)
                .ByCriteria(criteria);

        }


        internal static ICollection<T> GetPreAlertItems<T>(PurchaseOrder order)
        {

            BinaryOperator criteria = new BinaryOperator("PurchaseOrder", order);
            return Repository.GetList<T>(order.Session)
                .ByCriteria(criteria);
            
        }

        public static ICollection<Order> GetOrderTemplates(IUnitOfWork uow)
        {
            var repo = Scout.Core.Data.GetRepository(uow);
            return repo.Find<Order>().Where(o => o.IsTemplate).ToList();
        }
    }
}