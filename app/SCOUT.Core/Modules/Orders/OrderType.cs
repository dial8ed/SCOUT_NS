namespace SCOUT.Core.Data
{
    public enum OrderType
    {
        ReturnNReplace = 1,
        ADEX = 2,
        PurchaseOrder = 3,
        SalesOrder = 4
    }


    public static class OrderTypeHelpers
    {
        public static OrderType GetOrderTypeFromString(string orderType)
        {
            switch(orderType)
            {
                case "Purchase Order":
                    return OrderType.PurchaseOrder;
                case "Sales Order":
                    return OrderType.SalesOrder;
                case "Return N Replace":
                    return OrderType.ReturnNReplace;
                case "Advanced Exchange":
                    return OrderType.ADEX;
               
            }                
            return  OrderType.PurchaseOrder;
        }
    }
}