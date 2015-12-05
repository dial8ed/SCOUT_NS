using System;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Core
{
    public class OrdersNewTemplateCommand : Command
    {
        private string m_orderType;

        public OrdersNewTemplateCommand(params object[] input) : base(input)
        {
            m_orderType = input[0] as string;
        }

        public override void Execute()
        {
            var orderType = OrderTypeHelpers.GetOrderTypeFromString(m_orderType);
            var order = OrderService.CreateOrderAsArg(orderType);
            ((Order)order[0]).IsTemplate = true;

            ViewLoader.Instance().CreateFormWithArgs<mainOrderForm>(true, order);

        }
    }
}