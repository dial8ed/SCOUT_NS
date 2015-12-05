using System;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;
using SCOUT.Core.Providers;

namespace SCOUT.Core.Services
{
    public class ReceivingService : ModuleService, IReceivingService
    {                
        public ReceivingService(IModule module) : base(module)
        {
              
        }

        public bool ReceiveUnit(ReceiptFacts facts)
        {
            if (Scout.Core.Service<IInventoryService>().DuplicateSNItemExists(facts.SerialNumber))
            {
                Logging.Log("Unit already exists " + facts.SerialNumber,LogType.Error);
                UserInteraction.Dialog.ShowMessage("This unit already exists: " + facts.SerialNumber,
                                                   UserMessageType.Error);
                return false;
            }

            Logging.Log("Receiving unit " + facts.SerialNumber, LogType.Information);

            if (UnitIsDfiled(facts))
                return true;
                     
            return CreateReceiptRecords(facts);                 
        }

        private bool UnitIsDfiled(ReceiptFacts facts)
        {
            Logging.Log("Checking if unit " + facts.SerialNumber + " is to be dfiled.", LogType.Information);

            CloseResolvedDfile(facts);

            if (facts.DisableDfileCheck)
                return false;
                
            if (facts.PurchaseOrder.Shopfloorline.DfileIsEnabled == false)
                return false;

            DfileCondition dfile = new DfileCondition();
            if (dfile.IsSatisfiedBy(facts))
            {
                DfileItem item =
                    Scout.Core.Service<IDfileService>()
                        .CreateDfileItem(facts, dfile.Message.ToString());
                    
                if(item != null)
                    UserInteraction.Dialog.ShowMessage("This is unit is to be dfiled for: " + dfile.Message.Message, UserMessageType.Warning, stubborn:true);

                return true;                
            }

            return false;
        }

        private void CloseResolvedDfile(ReceiptFacts facts)
        {
            Scout.Core.Service<IDfileService>()
                .CloseDfileItemFromReceipt(facts);      
        }
      
        private bool CreateReceiptRecords(ReceiptFacts facts)
        {                     
            if(!new ReceiptValidator(facts).Validated())
                return false;
            try
            {
                IUnitOfWork uow = facts.Session as IUnitOfWork;

                Receipt receipt = CreateReceipt(facts);

                CreateInventoryItem(receipt);
                CreateSerializedUnit(receipt);
                CreateTransaction(receipt, facts.SourceType);
               
                MapToPreAlertItem(facts, receipt.UnitTrackingId);                
                ProcessRouting(receipt.PurchaseLineItem, receipt.Item);
                UpdateLineItemStatus(receipt);

                //Persist               
                Scout.Core.Data.Save(uow);
                
                // Check if the unit should be captured
                Scout.Core.Service<ICaptureService>()
                    .RunCaptureCheck(receipt.Item, "PURREC");

                // Print Traveler Label
                Scout.Core.Service<IInventoryService>()
                    .PrintTravelerLabel(receipt.Item);

                return true;
            }
            catch (Exception ex)
            {
                UserInteraction.Dialog.ShowMessage(
                    "There was an error saving the receipt " + ex.Message,
                    UserMessageType.Exception
                    );

                Logging.Log("Error receiving unit [" + facts.SerialNumber + "] " + ex.Message, LogType.Error); 

                return false;
            }
        }

        private void UpdateLineItemStatus(Receipt receipt)
        {
            if (receipt.PurchaseLineItem != null)
                receipt.PurchaseLineItem.UpdateStatusFromReceipt(receipt.Qty); 
        }

        private void MapToPreAlertItem(ReceiptFacts facts, string lotid)
        {
            IPreAlert preAlert = 
                OrderService.GetPreAlertByType(facts.PurchaseOrder.PreAlertType);

            if (preAlert == null)
                return;

            string serialNumber = facts.SerialNumber;

            if (!string.IsNullOrEmpty(facts.SerialNumber))
            {
                serialNumber = serialNumber.Trim();
                serialNumber = serialNumber.ToUpper();

                IPreAlertItem item =
                    preAlert.GetItemBySerialNumber(facts.PurchaseOrder, serialNumber);

                if (item != null)
                    item.LotId = lotid;     
            }
                   
        }

        private Receipt CreateReceipt(ReceiptFacts facts)
        {
            Receipt receipt = 
                new FactsReceiptMapper().MapFrom(facts);

            return receipt;            
        }

        private void CreateInventoryItem(Receipt receipt)
        {
            // Setup item detail [STKLOT]
            InventoryItem item =
                new ReceiptInventoryItemDetailMapper().MapFrom(receipt);

            receipt.Item = item;            
        }

        private void CreateTransaction(Receipt receipt, string sourceType)
        {
            // Setup transactions [STKTRANS]
            Transaction transaction =
                new ReceiptTransactionMapper().MapFrom(receipt);

            transaction.TransType = sourceType;
        }

        private void CreateSerializedUnit(Receipt receipt)
        {
            //Setup sn tracking [STKRTNTRACKING]
            if (receipt.SerialNumber.Length > 0)
            {
                SerializedUnit serializedUnit =
                    new ReceiptSerializedUnitMapper().MapFrom(receipt);

                receipt.Item.SerializedUnit = serializedUnit;
            }
        }

        private void ProcessRouting(PurchaseLineItem lineItem, InventoryItem inventoryItem)
        {
            if (lineItem == null)
                return;

            // Get the post receipt service route from the line item if it exists            
                if (lineItem.ServiceRoute != null 
                    && inventoryItem.SerialNumber != "NON SERIALIZED")
                {
                    Scout.Core.Service<IShopfloorService>()
                    .StageUnitAtFirstStation(lineItem.ServiceRoute, inventoryItem);
                }           
        }

        public bool DeleteReceipt(Receipt receipt)
        {
            try
            {              
                InventoryItem item = InventoryRepository.GetItemById(receipt.Session, receipt.UnitTrackingId);
                if(item == null)
                {
                    UserInteraction.Dialog.ShowMessage("This unit is no longer in stock and cannot be un-received.", UserMessageType.Information);
                    return false;
                }
                                        
                // Verify the unit is in a pre process domain before deleting the receipt.
                if (!item.Domain.IsPreProcessArea)
                {
                    UserInteraction.Dialog.ShowMessage(
                        "This unit is not in a pre process [REC] domain and cannot be un-received.",
                        UserMessageType.Validation
                        );

                    return false;
                }

                string undoReason = Scout.Core.UserInteraction.Dialog.GetInput
                    ("What is the reason for un-receiving this unit?", true);

                if(receipt.PurchaseLineItem != null)
                    receipt.PurchaseLineItem.UpdateStatusFromUnReceipt(receipt.Qty);
                              
                // Delete the item detail
                item.Delete();

                // Write a DELREC transaction to the transaction table
                Transaction transaction =
                    new DeletedReceiptTransactionMapper().MapFrom(receipt);

                // Write the reason for un-receiving this unit into the transaction log
                transaction.Comments = undoReason;

                Scout.Core.Data.Delete(receipt.Session, receipt, true);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error deleting the receipt. " + ex.Message, Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // TODO: delegate method to abstract label printing method.
        public void PrintReceiveLabel(Receipt receipt)
        {
            // Guard
            // Do not print labels for serialized units on carts
            // TODO: Write Specification(pattern) for this!
            if (receipt.ReceivingCart != null && receipt.Item.SerializedUnit != null)
                return;

            //ReceivingLabel label = ReceivingLabel.GetReceivingLabel();
            ZPLLabel label = ZPLLabel.GetLabelByName("CHARTER_REC");
            label.SetLabelValues(
                ReceivingLabelDetail.GetLabelDetailByLotId(
                    receipt.UnitTrackingId).ToLabelArgs());

            label.Print();
        }

        public void PrintIdLabel(Receipt receipt)
        {
            ZPLLabel label = ZPLLabel.GetLabelByName("ID_LABEL");
            label.SetLabelValues(new object[] { receipt.UnitTrackingId });
            label.Print();
        }

        public static Receipt GetReceipt(InventoryItem item)
        {
            BinaryOperator op1 = new BinaryOperator("Item", item);

            return Repository
                .Get<Receipt>(item.Session)
                .ByCriteria(op1);          
        }
    }
}