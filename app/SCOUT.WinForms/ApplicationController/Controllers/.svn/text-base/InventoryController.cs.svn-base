using System;
using System.Collections.Generic;

namespace SCOUT.WinForms.Core
{
    public class InventoryController : ApplicationController.Controllers.ApplicationController
    {        
        public InventoryController()
        {
            AddCommand(InventoryCommands.Transfer, typeof (InventoryTransferDomainCommand));            
            AddCommand(InventoryCommands.NewCapture, typeof(InventoryCaptureNewCommand));
            AddCommand(InventoryCommands.ReceiveItems, typeof(InventoryReceiveItemsCommand));
            AddCommand(InventoryCommands.ShipItems, typeof(InventoryShipItemsCommand));
        }
    }
}