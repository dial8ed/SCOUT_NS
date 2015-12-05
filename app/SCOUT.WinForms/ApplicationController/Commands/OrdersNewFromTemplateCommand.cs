using System;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Orders;

namespace SCOUT.WinForms.Core
{
    public class OrdersNewFromTemplateCommand : Command
    {
        public OrdersNewFromTemplateCommand(params object[] input) : base(input)
        {

        }

        public override void Execute()
        {
            // Choose Order Template
            var view = new OrderTemplateSelectionView();
            Order order = null;
            view.OnItemSelected += (ot) => order = OrderService.CreateFromTemplate(ot);
            view.OnEditTemplateSelected += (ot) => order = ot;
            ViewLoader.Instance().ShowForm(view, false);
            
            // Copy Template Items to New Order
            if (order == null)
                return;
                                                    
            // Show new order in form
            ViewLoader.Instance().CreateFormWithArgs<mainOrderForm>(true, order);

        }
    }
}