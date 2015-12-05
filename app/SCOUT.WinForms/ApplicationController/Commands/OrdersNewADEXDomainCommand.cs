using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Core
{
    public class OrdersNewADEXDomainCommand : Command
    {
        public override void Execute()
        {
            ViewLoader.Instance().CreateFormWithArgs<mainOrderForm>(
                true,
                OrderService.CreateOrderAsArg(OrderType.ADEX)
                );
        }
    }
}