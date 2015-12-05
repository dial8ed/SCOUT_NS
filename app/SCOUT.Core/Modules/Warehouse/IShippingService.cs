using System;
using System.Collections.Generic;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface IShippingService
    {
        /// <summary>
        /// Ships a inventory item via a ShipmentScript
        /// </summary>
        /// <param name="facts"></param>
        /// <returns></returns>
        bool Ship(ShipmentFacts facts);

        bool Ship(SalesOrder order, InventoryItem item, int qty);

        /// <summary>
        /// Batch ships a list of inventory items
        /// </summary>
        /// <param name="order"></param>
        /// <param name="items"></param>
        void ProcessBulkShipments(SalesOrder order,List<InventoryItem> items);

        /// <summary>
        /// Unships a list of shipments.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="shipments"></param>
        void UndoShipments(IUnitOfWork uow,List<Shipment> shipments);

        /// <summary>
        /// Unships a single shipment
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="shipment">The shipment to undo</param>
        void UndoShipment(IUnitOfWork uow, Shipment shipment, string undoReason);

        void SetPacklistPrintDate(string packlistId, DateTime shipDate);
    }
}