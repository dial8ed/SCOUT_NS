using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;
using SCOUT.Core.Services;
using StructureMap;

namespace SCOUT.Core.Data
{

    /// <summary>
    /// Provides the interface for performing shipping transactions
    /// </summary>
    internal class ShippingService : ModuleService, IShippingService
    {        
        private ShipmentFacts m_facts;
        
        public ShippingService(IModule module) : base(module)
        {
                
        }

        public bool Ship(SalesOrder salesOrder, InventoryItem item, int shipQty)
        {            
            // Create the shipping facts
            var facts = new ShipmentFacts(salesOrder, item, shipQty, "", null);
            return Ship(facts);
        }


        /// <summary>
        /// Ships a inventory item via a ShipmentScript
        /// </summary>
        /// <param name="facts"></param>
        /// <returns></returns>
        public bool Ship(ShipmentFacts facts)
        {
            // Check if shipment is valid prior to shipping            
            if (!new ShipmentValidator(m_facts).Validated())
                return false;

            try
            {
                var shipper = Scout.Core.Container.GetInstance<IShipmentScript>();

                return 
                    shipper.Run(facts, facts.SalesOrder.GetCurrentPacklist());
                
            }                
                    
            catch (Exception ex)
            {
                UserInteraction.Dialog.ShowMessage("There was a error saving this shipment. " 
                    + ex.Message, UserMessageType.Exception);                
            }

            return false;
        }

        /// <summary>
        /// Batch ships a list of inventory items
        /// </summary>
        /// <param name="order"></param>
        /// <param name="items"></param>
        public void ProcessBulkShipments(SalesOrder order,List<InventoryItem> items)        
        {
            foreach (InventoryItem item in items)
            {
                Ship(order, item, item.Qty);
            }
        }

        /// <summary>
        /// Unships a list of shipments.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="shipments"></param>
        public void UndoShipments(IUnitOfWork uow,List<Shipment> shipments)
        {            
           if (UserInteraction.Dialog.AskQuestion
                    ("Are you sure you want to undo these shipments?") == DialogResult.No)
                    return;

            string undoReason =
            UserInteraction.Dialog.GetInput
                ("What is the reason for un-shipping these units?", true);

            foreach (Shipment shipment in shipments)
            {
                uow = shipment.Session;                
                UndoShipment(uow,shipment, undoReason);               
            }

            Scout.Core.Data.Save(uow);            
        }
       
        /// <summary>
        /// Unships a single shipment
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="shipment">The shipment to undo</param>
        public void UndoShipment(IUnitOfWork uow, Shipment shipment, string undoReason)
        {
            try
            {
                // Ask the line item to update its status from the shipment reversal
                if (shipment.LineItem != null)
                    shipment.LineItem.UpdateStatusFromUnShipment(shipment.Qty);

                // Create a transaction entry for the shipment reversal
                Transaction transaction =
                    new UndoShipmentTransactionMapper().MapFrom(shipment);

                // Write the reason for the unship to the transaction log.
                transaction.Comments = undoReason;

                IInventoryService inventory = Scout.Core.Service<IInventoryService>();

                // Add the ship qty back into the inventory item qty 
                inventory.UpdateUnitQtyFromUndoShipment(shipment);

                // Undo the serialized record closing.
                inventory.UpdateSerialInfoForUndoShipment(shipment);

                // Delete the packlist if this is the last unit on it
                if(shipment.Packlist.Shipments.Count == 1)
                    uow.Delete(shipment.Packlist, false);
                
                uow.Delete(shipment, false);
                
            }
            catch (Exception ex)
            {                
                UserInteraction.Dialog.ShowMessage(
                    "There was a error undoing this shipment. " + ex.Message,
                    UserMessageType.Error
                    );

                //Logging.Log(ex.Message, LogType.Exception);
            } 
        }

        public void SetPacklistPrintDate(string packlistId, DateTime printDate)
        {
            IUnitOfWork uow = Scout.Core.Data.GetUnitOfWork();
            Packlist packlist =
                Scout.Core.Data.Get<Packlist>(uow).ByCriteria("[PacklistId]='" + packlistId + "'");

            packlist.PrintDate = printDate;
            uow.Commit();
            
        }
    }
}