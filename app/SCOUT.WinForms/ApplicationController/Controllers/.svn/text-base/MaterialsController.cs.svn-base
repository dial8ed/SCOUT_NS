using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.ApplicationController.Controllers
{
    public class MaterialsController : ApplicationController
    {
        public MaterialsController()
        {
            AddCommand(MaterialCommands.CreatePO, typeof(MaterialsCreatePOCommand));
            //AddCommand(MaterialCommands.CreateSO, typeof(MaterialsCreateSOCommand));
            AddCommand(MaterialCommands.IssueOut, typeof(MaterialsIssueOutCommand));
            AddCommand(MaterialCommands.WarehouseReturn, typeof(MaterialsWarehouseReturnCommand));
            AddCommand(MaterialCommands.ReceivePO, typeof(MaterialsReceivePOCommand));
            AddCommand(MaterialCommands.SearchWarehouseItems, typeof(MaterialsSearchWarehouseCommand));
            AddCommand(MaterialCommands.SearchTransactions, typeof(MaterialsSearchTransactionsCommand));
            AddCommand(MaterialCommands.PutAway, typeof(MaterialsPutAwayCommand));
            AddCommand(MaterialCommands.IssueOut, typeof(MaterialsIssueOutCommand));
            AddCommand(MaterialCommands.SearchConsumableItems, typeof(MaterialsSearchConsumablesCommand));
            AddCommand(MaterialCommands.LocationTransfer, typeof(MaterialsLocationTransferCommand));
            AddCommand(MaterialCommands.QtyAdjustment, typeof(MaterialsQtyAdjustmentCommand));
            AddCommand(MaterialCommands.SearchAllInventory, typeof(MaterialsSearchAllCommand));
            AddCommand(MaterialCommands.ConsumeBomConfiguration, typeof(MaterialsConsumeBomConfigurationCommand));            
        }
    }
}