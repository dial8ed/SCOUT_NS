using System;
using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;
using SCOUT.Core.Modules.Warehouse.Inventory;

namespace SCOUT.Core.Services
{
    public class InventoryService : ModuleService, IInventoryService
    {
        public InventoryService(IModule module) : base(module)
        {
        }

        public void UpdateUnitQtyFromShipment(Shipment shipment)
        {
            if (shipment.Session == null)
                throw new NotImplementedException("The shipment object provided is not associated with a UnitOfWork");

            InventoryItem item = shipment.Item;
            if (item != null)
            {
                item.Qty -= shipment.Qty;
                item.Tote = null;
            }
            else
                throw new NotImplementedException(
                    "A valid inventory item was not found when trying to deduct a shipment qty.");
        }

        public void UpdateSerialInfoForShipment(Shipment shipment)
        {
            if (shipment.Session == null)
                throw new NotImplementedException("The shipment object provided is not associated with a UnitOfWork");

            SerializedUnit serializedUnit = shipment.Item.SerializedUnit;
            if (serializedUnit != null)
            {
                serializedUnit.ReturnEndDate = DateTime.Now;
                serializedUnit.EndIdent = shipment.Item.SerialNumber;
            }
        }

        // TODO: Should be Tote.Remove(item);
        public void RemoveItemFromTote(InventoryItem item)
        {
            item.Tote = null;
        }

        /// <summary>
        /// Adds a inventory item to a tote
        /// </summary>
        /// <param name="tote">Tote</param>
        /// <param name="item">InventoryItem</param>
        public void AddItemToTote(Tote tote, InventoryItem item)
        {
            if (item.Tote != null)
                RemoveItemFromTote(item);

            item.Tote = tote;
        }


        /// <summary>
        /// Subtracts the shipment qty from the inventory qty
        /// </summary>
        /// <param name="shipment"></param>
        public void UpdateUnitQtyFromUndoShipment(Shipment shipment)
        {
            InventoryItem item = shipment.Item;
            if (item != null)
            {
                item.Qty += shipment.Qty;
            }
        }

        public void UpdateSerialInfoForUndoShipment(Shipment shipment)
        {
            SerializedUnit serializedUnit = shipment.Item.SerializedUnit;
            if (serializedUnit != null)
            {
                serializedUnit.ReturnEndDate = DateTime.MinValue;
            }
        }

        public void TransferItemToDomain(InventoryItem item, Domain domain)
        {
            item.Domain = domain;
            item.Shopfloorline = domain.Parent;
            item.Site = item.Shopfloorline.Parent;
        }


        public InventoryItem GetItemById(IUnitOfWork uow, string lotId)
        {
            return InventoryRepository.GetItemById(uow, lotId);
        }


        public InventoryItem GetItemRecordById(IUnitOfWork uow, string lotid)
        {
            return InventoryRepository.GetItemRecordById(uow, lotid);
        }


        public SerializedUnit GetSerializedRecordBySN(string sn)
        {
            throw new NotImplementedException();
        }


        public InventoryItem GetItemBySN(IUnitOfWork uow, string sn)
        {
            return InventoryRepository.GetItemBySN(uow, sn);
        }

        public SerializedUnit GetSerializedUnitBySN(string sn)
        {
            return InventoryRepository.GetSerializedUnitBySN(sn);
        }

        public SerializedUnit GetSerializedUnitById(IUnitOfWork uow, string lotId)
        {
            return InventoryRepository.GetSerializedUnitById(uow, lotId);
        }

        public InventoryItem GetItemByLotIdOrSerialNumber(IUnitOfWork uow, string identifier)
        {
            return InventoryRepository.GetItemByLotIdOrSerialNumber(uow, identifier);
        }

        public bool DuplicateSNItemExists(string sn)
        {
            return GetSerializedUnitBySN(sn) != null;
        }


        public bool SaveInventoryItem(InventoryItem item)
        {
            try
            {
                Scout.Core.Data.Save(item.Session);
                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
            }

            return false;
        }


        public void PrintTravelerLabel(InventoryItem item)
        {
            ReceivingLabelDetail labelDetail = ReceivingLabelDetail.GetLabelDetailByLotId(item.LotId);

            ReceivingLabel lbl = ReceivingLabel.GetReceivingLabel();
            lbl.SetLabelValues(item.LotId, item.SerialNumber, item.PartNumber, item.Part.Description,
                               labelDetail.ReturnType, labelDetail.Rma, labelDetail.ReceivedBy,
                               labelDetail.ReceiveDate, labelDetail.Comments, labelDetail.Notes, labelDetail.Process, labelDetail.Program);
            lbl.Print();
        }


        public bool ChangeSerialNumber(InventoryItem item, string newSerialNumber)
        {
            // TODO: Extract to ChangeSerialNumberValidator().Validated
            if (GetItemBySN(item.Session, newSerialNumber) != null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "A unit with this serial number already exists in inventory",
                    UserMessageType.Error);

                return false;
            }

            try
            {
                Scout.Core.Service<ITransactionService>().CreateTransaction("SNCHANGE", item, "", "",
                                                                            item.SerialNumber + "->" + newSerialNumber,
                                                                            "");

                item.SerializedUnit.EndIdent = newSerialNumber;
                item.SerialNumber = newSerialNumber;

                Scout.Core.Data.Save(item.Session);
                return true;
            }
            catch (Exception ex)
            {
                UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
                return false;
            }
        }


        public NSLotIdSerial GetNSLotBySerialNumber(IUnitOfWork uow, string serialNumber)
        {
            return InventoryRepository.GetNSLotBySerialNumber(uow, serialNumber);
        }


        public InventoryServiceProperties GetServicePropertiesForItem(IUnitOfWork uow, InventoryItem item)
        {
            return InventoryRepository.GetServicePropertiesForItem(uow, item);
        }

        public ICollection<InventoryCaptureProperties> GetAllCaptureUnitsByCritieriaString(IUnitOfWork uow,
                                                                                           string criteria)
        {
            return InventoryRepository.GetAllCaptureUnitsByCriteriaString(uow, criteria);
        }

        public IEnumerable<AdjustmentTransactionType> GetAllAdjustmentTransactionTypes()
        {
            return AdjustmentTransactionType.AsList();
        }
    }
}