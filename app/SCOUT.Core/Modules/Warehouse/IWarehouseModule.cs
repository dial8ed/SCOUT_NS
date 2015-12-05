using SCOUT.Core.Services;

namespace SCOUT.Core.Modules
{
    public interface IWarehouseModule : IModule
    {
        IShippingService Shipping { get; }
        IReceivingService Receiving { get; }
        IInventoryService Inventory { get; }
        IAreaService Areas { get; }
        ICaptureService Captures { get; }
        ITransactionService Transactions { get; }
    }
}