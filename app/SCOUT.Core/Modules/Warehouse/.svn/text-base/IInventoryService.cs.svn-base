using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.Core.Modules.Warehouse.Inventory;

namespace SCOUT.Core.Services
{
    public interface IInventoryService
    {
        void UpdateUnitQtyFromShipment(Shipment shipment);
        void UpdateSerialInfoForShipment(Shipment shipment);
        void RemoveItemFromTote(InventoryItem item);
        
        /// <summary>
        /// Adds a inventory item to a tote
        /// </summary>
        /// <param name="tote">Tote</param>
        /// <param name="item">InventoryItem</param>
        void AddItemToTote(Tote tote, InventoryItem item);

        /// <summary>
        /// Add the shipment qty to the inventory qty
        /// </summary>
        /// <param name="shipment"></param>
        void UpdateUnitQtyFromUndoShipment(Shipment shipment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipment"></param>
        void UpdateSerialInfoForUndoShipment(Shipment shipment);
        void TransferItemToDomain(InventoryItem item, Domain domain);
        InventoryItem GetItemById(IUnitOfWork uow, string lotId);
        InventoryItem GetItemRecordById(IUnitOfWork uow, string lotid);
        SerializedUnit GetSerializedRecordBySN(string sn);
        InventoryItem GetItemBySN(IUnitOfWork uow, string sn);
        SerializedUnit GetSerializedUnitBySN(string sn);
        SerializedUnit GetSerializedUnitById(IUnitOfWork uow, string lotId);
        InventoryItem GetItemByLotIdOrSerialNumber(IUnitOfWork uow, string identifier);
        bool DuplicateSNItemExists(string sn);                
        bool SaveInventoryItem(InventoryItem item);
        void PrintTravelerLabel(InventoryItem item);
        bool ChangeSerialNumber(InventoryItem item, string newSerialNumber);
        NSLotIdSerial GetNSLotBySerialNumber(IUnitOfWork uow, string serialNumber);
        InventoryServiceProperties GetServicePropertiesForItem(IUnitOfWork uow, InventoryItem item);
        ICollection<InventoryCaptureProperties> GetAllCaptureUnitsByCritieriaString(IUnitOfWork uow, string criteria);
        IEnumerable<AdjustmentTransactionType> GetAllAdjustmentTransactionTypes();        
    }
}