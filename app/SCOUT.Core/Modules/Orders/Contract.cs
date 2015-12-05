using System;
using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    public class Contract
    {       
        public static List<Type> GetContractTypesFor(OrderType orderTypes)
        {

            List<Type> list = new List<Type>();

            switch (orderTypes)
            {
                case OrderType.ADEX:
                case OrderType.ReturnNReplace:
                    list.Add(typeof(SalesOrder));
                    list.Add(typeof(PurchaseOrder));
                    break;
                case OrderType.PurchaseOrder:
                    list.Add(typeof(PurchaseOrder));
                    break;
                case OrderType.SalesOrder:
                    list.Add(typeof(SalesOrder));
                    break;
            }

            return list;           
        }
    }
}