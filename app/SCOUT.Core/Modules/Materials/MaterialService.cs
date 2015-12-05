using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo.DB.Exceptions;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Materials;
using SCOUT.Core.Modules.Shopfloor;
using SCOUT.Core.Modules.Warehouse.Inventory;
using SCOUT.Core.Providers.Data;
using SCOUT.Core.Utils;

namespace SCOUT.Core.Services
{
    public class MaterialService
    {
        public static bool ReceiveMaterial(MaterialPurchaseOrder order, Part part, int quantity, string scannedPartNumber)
        {
            if (!new MaterialReceiptValidator(order, part, quantity).Validated())
                return false;
            try
            {
                AddMaterialToDomain(part, quantity, order.ReceiveDomain);
                WriteMaterialReceiptTransaction(order, part, quantity, order.ReceiveDomain, scannedPartNumber);
                UpdateLineItemStatus(order, part, quantity);

                Scout.Core.Data.Save(order.Session);                
                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
            }

            return false;
        }

        private static void UpdateLineItemStatus(MaterialPurchaseOrder order, Part part, int quantity)
        {
            MaterialPurchaseLineItem lineItem = order.GetLineItemForPart(part);
            if(lineItem != null)
            {
                lineItem.UpdateStatusFromReceipt(quantity);
            }            
        }

        private static void WriteMaterialReceiptTransaction(MaterialPurchaseOrder order, Part part, int quantity, Domain domain, string scannedPartNumber)
        {
            Transaction trans = TransactionFactory.CreateTransaction(part.Session, "MATLREC");
            trans.TransType = "MATLREC";
            trans.ArrivalLocation = domain.FullLocation;
            trans.Part = part;
            trans.Qty = quantity;
            trans.TransRef = order.Id.ToString();
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.Item = InventoryRepository.GetItemRecordById(trans.Session, "LRAWMATERIALS000");
            trans.Comments = scannedPartNumber; 
        }

        private static void AddMaterialToDomain(Part part, int quantity, Domain domain)
        {
            try
            {           
                var repo = part.Session.AsRepository();
                var whse = new MaterialsWarehouseInventory(repo);           
                whse.IncreaseItemQuantity(part, domain, null, quantity);
                repo.Save();
            }
            catch (Exception ex)
            {
               Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
            }
        }

        public static ICollection<MaterialWarehouseItem> GetIssuableItemsByPart(Part part)
        {
            return MaterialRepository.GetIssuableItemsByPart(part);
        }

        public static ICollection<MaterialWarehouseItem> GetItemsNeedingPutAway(Part part)
        {
            return MaterialRepository.GetItemsNeedingPutAway(part);
        }

        public static ICollection<MaterialConsumableItem> GetConsumableItemsByPart(Part part)
        {
            return MaterialRepository.GetConsumableItemsByPart(part);           
        }



        public static bool PutAwayMaterial(MaterialWarehouseItem item, RackLocation location, int qty, string comments)
        {
            if (!new PutAwayMaterialValidator(item, location, qty).Validated())
                return false;

            var repo = location.Session.AsRepository();
            var warehouse = new MaterialsWarehouseInventory(repo);

            warehouse.IncreaseItemQuantity(item.Part, item.Domain, location.Label, qty);
            warehouse.DecreaseItemQuantity(item.Part, item.Domain, null, qty);

            // Write Transaction
            WriteMaterialPutAwayTransaction(item.Part, qty, item.Domain, location.Label, comments);

            repo.Save();
            
            return true;
        }

        private static void WriteMaterialPutAwayTransaction(Part part, int quantity, Domain domain, string rackLocation, string comments)
        {
            Transaction trans = TransactionFactory.CreateTransaction(part.Session, "MATLPUTAWAY");
            trans.TransType = "MATLPUTAWAY";
            trans.DepartLocation = domain.FullLocation;
            trans.ArrivalLocation = rackLocation;
            trans.Part = part;
            trans.Qty = quantity;
            trans.TransRef = "Material Put Away";
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.Item = InventoryRepository.GetItemRecordById(trans.Session, "LRAWMATERIALS000");
            trans.Comments = comments;
        }

        public static bool IssueOutMaterial(MaterialWarehouseItem item, Shopfloorline shopfloorline, int qty)
        {
            if(!new MaterialIssueOutValidator(item, shopfloorline, qty).Validated())
                return false;

            try
            {            
                var repo = Scout.Core.Data.GetRepository(shopfloorline.Session);
                var warehouse = new MaterialsWarehouseInventory(repo);
                var consumable = new MaterialsConsumableInventory(repo);

                consumable.IncreaseItemQty(item.Part, shopfloorline, qty);
                warehouse.DecreaseItemQuantity(item.Part, item.Domain, item.RackLocation, qty);

               // Write the transaction
                WriteIssueOutTransaction(item, qty, shopfloorline);

                //Commit
                return repo.Save();
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }
        }

        private static void WriteIssueOutTransaction(MaterialWarehouseItem item, int qty, Shopfloorline shopfloorline)
        {
            Part part = item.Part;
            Transaction trans = TransactionFactory.CreateTransaction(part.Session, "MATLISSUEOUT");
            trans.TransType = "MATLISSUEOUT";
            trans.DepartLocation = item.Domain.FullLocation + "-" + item.RackLocation;
            trans.ArrivalLocation = shopfloorline.FullLocation;
            trans.Part = part;
            trans.Qty = qty;
            trans.TransRef = "Material Issue Out";
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.Item = InventoryRepository.GetItemRecordById(trans.Session, "LRAWMATERIALS000");     
        }

        private static void WriteWarehouseReturnTransaction(MaterialConsumableItem item, Domain domain, int qty)
        {
            Part part = item.Part;
            Transaction trans = TransactionFactory.CreateTransaction(part.Session, "MATLWHRETURN");
            trans.TransType = "MATLWHRETURN";
            trans.DepartLocation = item.Shopfloorline.FullLocation;
            trans.ArrivalLocation = domain.FullLocation;
            trans.Part = part;
            trans.Qty = qty;
            trans.TransRef = "Material Warehouse Return";
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.Item = InventoryRepository.GetItemRecordById(trans.Session, "LRAWMATERIALS000");   
        }

        public static bool ReturnMaterialToWarehouse(MaterialConsumableItem item,Domain domain, int qty)
        {
           if(!new MaterialWarehouseReturnValidator(item, domain, qty).Validated())
               return false;

            // Put the material in the warehouse
            AddMaterialToDomain(item.Part, qty, domain);

            // Remove the items from the consumable inventory
            item.Qty -= qty;

            // Write transactions
            WriteWarehouseReturnTransaction(item, domain, qty);

            // Commit
            Scout.Core.Data.Save(item.Session);

            return true;
        }

        public static bool TransferMaterialToLocation(MaterialWarehouseItem item, Domain domain, string location, int qty, string comments)
        {
            if(!new MaterialLocationTransferValidator(item,domain,location,qty).Validated())
                return false;

            var repo = Scout.Core.Data.GetRepository(domain.Session);
            var warehouse = new MaterialsWarehouseInventory(repo);

            try
            {            
                warehouse.DecreaseItemQuantity(item.Part, item.Domain, item.RackLocation, qty);
                warehouse.IncreaseItemQuantity(item.Part, item.Domain, location, qty);

                // Write Transaction
                WriteTransferLocationTransaction(item, domain, location, qty, comments);

                return repo.Save();
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }
        }

        private static void WriteTransferLocationTransaction(MaterialWarehouseItem item, Domain domain, string location, int qty, string comments)
        {
            Part part = item.Part;
            Transaction trans = TransactionFactory.CreateTransaction(part.Session, "MATLTRANSFER");
            trans.TransType = "MATLTRANSFER";
            trans.DepartLocation = item.RackLocation;
            trans.ArrivalLocation = location;
            trans.Part = part;
            trans.Qty = qty;
            trans.TransRef = "Material Location Transfer";
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.Item = InventoryRepository.GetItemRecordById(trans.Session, "LRAWMATERIALS000");
            trans.Comments = comments;
        }

        public static bool AdjustMaterialWarehouseItem(Part part, Domain domain, string rackLocation, int qty, string comments, AdjustmentTransactionType sourceType, MessageListener messageListener)
        {
            var repo = Scout.Core.Data.GetRepository(part.Session);
            var whse = new MaterialsWarehouseInventory(repo);            

            MaterialWarehouseItem item;

            try
            {            
                // Adjust the quantity
                if (sourceType.Direction == "IN")
                    item = whse.IncreaseItemQuantity(part, domain, rackLocation, qty);
                else
                {
                    item = whse.DecreaseItemQuantity(part, domain, rackLocation, qty);           
                }

                // Write the transaction
                WriteQtyAdjustmentTransaction(item, qty, comments, sourceType);

            return repo.Save();

            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }
        }

        public static bool AdjustMaterialConsumableItem(Part part, Shopfloorline sfl, int qty, string comments, AdjustmentTransactionType sourceType, MessageListener messages)
        {
            var repo = Scout.Core.Data.GetRepository(part.Session);
            var consumable = new MaterialsConsumableInventory(repo);
            
            MaterialConsumableItem item;

            try
            {
                if (sourceType.Direction == "IN")
                    item = consumable.IncreaseItemQty(part, sfl, qty);
                else
                    item = consumable.DecreaseItemQty(part, sfl, qty);
            
                WriteQtyAdjustmentTransaction(item, qty, comments, sourceType);
                

                return repo.Save();
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }             
        }
        
        private static void WriteQtyAdjustmentTransaction(IMaterialItem item, int adjustmentQty, string comments, AdjustmentTransactionType sourceType)
        {
            if (item == null)
                return;
           
            string itemLocation = "";
            
            if (item is MaterialWarehouseItem)
                itemLocation = item.RackLocation ?? item.Domain.FullLocation;
            else if (item is MaterialConsumableItem)
                itemLocation = item.Shopfloorline.FullLocation;

            Part part = item.Part;
            Transaction trans = TransactionFactory.CreateTransaction(part.Session, sourceType.Code);
            trans.TransType = sourceType.Code;

            if(sourceType.Direction == "IN")
                trans.ArrivalLocation = itemLocation;   
            else                               
                trans.DepartLocation = itemLocation;
                            
            trans.Part = part;
            trans.Qty = adjustmentQty;
            trans.TransRef = "Material Qty Adjustment";
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.Item = InventoryRepository.GetItemRecordById(trans.Session, "LRAWMATERIALS000");
            trans.Comments = comments;
            
        }

        public static ICollection<MaterialWarehouseItem> GetWarehouseItemsByPart(Part part)
        {
            return MaterialRepository.GetWarehouseItemsByPart(part);
        }


        /// <summary>
        /// Gets a <see cref="Part"/> by searching the parts inventory.
        /// If no match is found, then it searches the materials cross reference tables
        /// for a match. 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="partNumber"></param>
        /// <returns>Null if no toplevel and no xref is found.</returns>
        public static Part GetPartByPartNumber(IUnitOfWork uow,string partNumber)
        {
            // Get the top level part by part number
            Part part = PartService.GetPartByPartNumber(uow, partNumber);

            // If no part is found, try cross referencing
            if (part == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("No top level part found. Attempting to cross reference.", UserMessageType.Warning);
                part = PartService.GetPartFromMaterialsXref(uow,
                                                            partNumber);
            }

            // If no cross reference is found then alert the user.
            if (part == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("Invalid part number. No Cross Reference Found.", UserMessageType.Error);

            return part;
        }


        public static Transaction WriteConsumptionTransaction(MaterialConsumableItem item, int qty, string description, string consumedInLotId)
        {
            Part part = item.Part;
            Transaction trans = TransactionFactory.CreateTransaction(item.Session,
                                                        "MATLCONSUME");

            trans.TransType = "MATLCONSUME";
            trans.DepartLocation = item.Shopfloorline.ToString();
            trans.ArrivalLocation = "";
            trans.Part = part;
            trans.Qty = qty;
            trans.TransRef = description;
            trans.TransBy = Security.UserSecurity.CurrentUser.Login;
            trans.TransDate = DateTime.Now;
            trans.ConsumedInLotId = consumedInLotId;
            trans.Item = InventoryRepository.GetItemRecordById(item.Session,
                                                               "LRAWMATERIALS000");

            return trans;
        }

        public static ICollection<BomConfiguration> GetStationBomConfigurations(IUnitOfWork uow, Shopfloorline shopfloorline)
        {
            return MaterialRepository.GetStationBomConfigurations(uow, shopfloorline);           
        }

        public static IEnumerable<AdjustmentTransactionType> GetMaterialAdjustmentTransactionTypes()
        {
            var adjustmentTypes = Scout.Core.Service<IInventoryService>().GetAllAdjustmentTransactionTypes();

            return adjustmentTypes.Where(t => !t.Code.Contains("WIP"))
                .ToList().PrefixCodesWith("MATL");            
        }

        public static bool ConsumeMaterial(ReplacementComponentFacts input)
        {
            if (!input.Shopfloorline.UseMaterialsInventory)
                return true;

            if (input.PartIn.DisableMaterialsTracking)
                return true;

            var inventoryController = new ServiceMaterialsInventoryController();

            var transId = inventoryController.Consume
                (input.PartIn.PartNumber, input.Shopfloorline.Id, 1, "Repair", input.Repair.Item.LotId);

            if (transId == default(int))
                return false;

            input.ConsumptionId = transId;

            return true;
        }

        public static bool UndoMaterialsConsumption(RepairComponent component,Transaction transaction)
        {
            var controller = new ServiceMaterialsInventoryController();
            return controller.Undo(component, transaction);
        }
    }
}