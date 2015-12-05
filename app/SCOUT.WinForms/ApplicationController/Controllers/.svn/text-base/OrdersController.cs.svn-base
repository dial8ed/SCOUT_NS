using System;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.ApplicationController.Controllers
{
    public class OrdersController : ApplicationController
    {
        public OrdersController()
        {
            AddCommand(OrdersCommands.New_PO, typeof(OrdersNewPODomainCommand));
            AddCommand(OrdersCommands.New_SO, typeof(OrdersNewSODomainCommand));
            AddCommand(OrdersCommands.New_RNR, typeof(OrdersNewRNRDomainCommand));
            AddCommand(OrdersCommands.New_ADEX, typeof(OrdersNewADEXDomainCommand));
            AddCommand(OrdersCommands.Search_Packlists, typeof(OrdersSearchPacklistsCommand));
            AddCommand(OrdersCommands.New_Template, typeof(OrdersNewTemplateCommand));
            AddCommand(OrdersCommands.New_FromTemplate, typeof(OrdersNewFromTemplateCommand));
        }
    }
}