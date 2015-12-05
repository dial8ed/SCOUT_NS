using System;
using SCOUT.WinForms.Inventory;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the inventory transaction form 
    /// </summary>
    public class InventoryTransferDomainCommand : ICommand
    {
        public void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<InventoryTransactionForm>(true,null);
        }
    }
}