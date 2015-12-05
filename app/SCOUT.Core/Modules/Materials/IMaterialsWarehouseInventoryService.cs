using System;

namespace SCOUT.Core.Modules.Materials
{
    public interface IMaterialsWarehouseInventoryService
    {
        // Remove part from consumable inventory
        Guid ConsumePartForRepair(int shopfloorlineId, int partId, int qty);

        // Undo repair part consumption
        bool UndoRepairPartConsumption(Guid consumptionId);
    }
}