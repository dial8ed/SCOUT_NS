using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{

    //TODO : Migrate all to OrderServices Class
    public class OrderService : MessageService
    {
        public static Order OrderWithIdentifiersExists(string rma, string po, string other, int id)
        {
            GroupOperator criteria =
                new GroupOperator(
                    new BinaryOperator("RMA", rma),
                    new BinaryOperator("PO", po),
                    new BinaryOperator("Other", other),
                    new BinaryOperator("Id", id, BinaryOperatorType.NotEqual));

            IUnitOfWork uow = Scout.Core.Data.GetUnitOfWork();

            Order order = Scout.Core.Data.Get<Order>(uow).ByCriteria(criteria);
           
            return order;
        }

        public static Order CreateOrder(OrderType type)
        {
            return OrderFactory.CreateOrder(type);
        }

        public static Order CreateOrder(IUnitOfWork uow, OrderType orderType)
        {
            return OrderFactory.CreateOrder(uow, orderType);
        }

        public static object[] CreateOrderAsArg(OrderType type)
        {
            return OrderFactory.CreateOrderAsArg(type);
        }

        public static int GetReceiveQtyForLine(Part part, PurchaseOrder purchaseOrder)
        {
            ReceivingPartSummary partSummary;
            try
            {
                partSummary =
                    OrderRepository.GetReceivingPartSummary(part, purchaseOrder);
            }
            catch (Exception)
            {
                return 0;
            }

            if (partSummary == null) return 0;

            return partSummary.Qty;
        }

        public static int GetReceiveQtyForLine(PurchaseLineItem lineItem)
        {
            ReceivingLineSummary partSummary;
            try
            {
                partSummary =
                    OrderRepository.GetReceivingLineSummary(lineItem);
            }
            catch (Exception ex)
            {
                return 0;
            }

            if (partSummary == null) return 0;

            return partSummary.Qty;
            
        }

        public static int GetShipQtyForLine(Part part, SalesOrder salesOrder)
        {
            ShippingPartSummary partSummary;
            try
            {
                partSummary =
                    OrderRepository.GetShippingSummaryForLine(part, salesOrder);
            }
            catch (Exception)
            {
                return 0;
            }

            if (partSummary == null) return 0;

            return partSummary.Qty;
        }

        public static int GetShipQtyForLine(SalesLineItem lineItem)
        {
            ShippingLineSummary partSummary;
            try
            {
                partSummary =
                    OrderRepository.GetShippingSummaryForLine(lineItem);
            }
            catch (Exception)
            {
                return 0;
            }

            if (partSummary == null) return 0;

            return partSummary.Qty;
        }

        public static bool ForceSerialFormatFor(PurchaseOrder order, Part part)
        {
            PurchaseLineItem pli = OrderRepository.GetPurchaseLineItemFor(order, part);

            if (pli == null)
                return false;

            return pli.ForceSerialFormat;
        }

        public static PartIdentType GetReceivingIdentTypeFor(PurchaseOrder order, Part part)
        {
            PartIdentType partIdentType;
            if (order.LineItems.Count > 0)
            {
                PurchaseLineItem purchaseLineItem = order.LineItemByPart(part);

                if (purchaseLineItem != null)
                    partIdentType = purchaseLineItem.IdentType;                   
                else
                    partIdentType = part.IdentType;
            }
            else
            {
                partIdentType = part.IdentType;
            }

            return partIdentType;
        }

        public static ICollection<Packlist> GetPacklistsForSalesOrder(IUnitOfWork uow, SalesOrder order)
        {
            return OrderRepository.GetPacklistsForSalesOrder(uow, order);            
        }

        public static List<IPreAlert> GetPreAlertTypeList()
        {
            List<IPreAlert> list = new List<IPreAlert>();

            list.Add(new DellPreAlert());
            list.Add(new XipD1PreAlert());
            list.Add(new XipGencoPreAlert());
            list.Add(new GenericPreAlert());

            return list;            
        }

        public static IPreAlert GetPreAlertByType(string type)
        {
            return Reflection.CreateInstanceOfType<IPreAlert>(type);
            //return Activator.CreateInstance(Type.GetType(type)) as IPreAlert;
        }

        public static DellReceiptLpnItem GetOpenDellReceiptLpnItem(string lpn)
        {
            return Scout.Core.Data
                .Get<DellReceiptLpnItem>(Scout.Core.Data.GetUnitOfWork())
                .ByCriteria(new BinaryOperator("Lpn", lpn));
        }

        public static List<IShipmentAllocation> GetShipmentAllocationMethods()
        {
            List<IShipmentAllocation> allocationMethods 
                = new List<IShipmentAllocation>();

            allocationMethods.Add(new OldestOrderAllocation());
            allocationMethods.Add(new DellLpnAllocation());
            allocationMethods.Add(new SameOrderAllocation());
            allocationMethods.Add(new OldestOrderAutoAllocation());
            return allocationMethods;
        }

        public static IList<string> GetAllShipMethods()
        {
            Select query;
            List<string> shipMethods;
            // Query gets most frequently used items first.
            query = new Select("ship_method")
                .From("sales_orders")
                .Where("ship_method IS NOT NULL")
                .AndWhere("ship_method <> ''")
                .GroupBy("ship_method")
                .OrderBy("ship_method, COUNT(ship_method) DESC");

            return query.ExecuteList<string>();

        }

        public static ICollection<Packlist> GetPacklistsByConfiguration(IUnitOfWork uow, ShippingConfiguration config)
        {            
            BinaryOperator criteria = new BinaryOperator("ShippingConfiguration", config);
            return Scout.Core.Data.GetList<Packlist>(uow).ByCriteria(criteria);
        }

        public static Order CreateFromTemplate(Order template)
        {
            var order = CreateOrder(template.Session,template.OrderType);
            order.CreatedFromTemplate = true;

            var po = order.GetContract<PurchaseOrder>() as PurchaseOrder;
            if (po != null)
            {
                var templatePo = template.GetContract<PurchaseOrder>() as PurchaseOrder;
                po.Buyer = templatePo.Buyer;
                po.Contact = templatePo.Contact;
                po.Notes = templatePo.Notes;
                po.Organization = templatePo.Organization;                
                po.RecDomain = templatePo.RecDomain;
                po.ReturnType = templatePo.ReturnType;
                po.RoutingRequired = templatePo.RoutingRequired;
                po.ServiceRoute = templatePo.ServiceRoute;
                po.SourceType = templatePo.SourceType;
                po.Shopfloorline = templatePo.Shopfloorline;
                po.Program = templatePo.Program;
                po.Status = templatePo.Status;
                po.WorkInstructions = templatePo.WorkInstructions;
            }


            var so = order.GetContract<SalesOrder>() as SalesOrder;
            if (so != null)
            {
                var templateSo = template.GetContract<SalesOrder>() as SalesOrder;
                so.Organization = templateSo.Organization;
                so.Shopfloorline = templateSo.Shopfloorline;
                so.BillToAccount = templateSo.BillToAccount;
                so.BillToAddress = templateSo.BillToAddress;
                so.Contact = templateSo.Contact;
                so.NewPacklistUponShipment = templateSo.NewPacklistUponShipment;
                so.Notes = templateSo.Notes;                
                so.PaymentTerms = templateSo.PaymentTerms;
                so.RequiredProgram = templateSo.RequiredProgram;
                so.RequiredServiceRoute = templateSo.RequiredServiceRoute;
                so.SalesRep = templateSo.SalesRep;
                so.SalesStatus = templateSo.SalesStatus;
                so.SalesTax = templateSo.SalesTax;
                so.ShipmentDomainStatus = templateSo.ShipmentDomainStatus;
                so.ShipMethod = templateSo.ShipMethod;
                so.ShipToAddress = templateSo.ShipToAddress;                
                so.TurnAroundTime = templateSo.TurnAroundTime;
                so.UseConfiguration = templateSo.UseConfiguration;   
                
            }

            return order;

        }
    }
}