using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    internal abstract class OrderFactory
    {
        internal static Order CreateOrder(OrderType orderType)
        {
            return new Order(orderType, Scout.Core.Data.GetUnitOfWork());
        }

        internal static object[] CreateOrderAsArg(OrderType orderType)
        {
            return new object[]{CreateOrder(orderType)};   
        }

        public static Order CreateOrder(IUnitOfWork uow, OrderType orderType)
        {
            return new Order(orderType, uow as UnitOfWork);
            
        }
    }
}