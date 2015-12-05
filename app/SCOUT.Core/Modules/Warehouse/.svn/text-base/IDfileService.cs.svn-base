using System.Collections.Generic;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface IDfileService
    {
        //DfileItem CreateDfileItem(int shopfloorlineId, int incomingPoId,
        //                          int partId, string serialNumber, string reason, string comments);

        DfileItem CreateDfileItem(ReceiptFacts facts, string reason);

        bool ResolveItem(DfileItem item, string resolution, string resolvedBy, DfileAction action, Order actionOrder);

        bool CloseItem(DfileItem item);

        ModuleProvider Providers { get; }
        IDfileRepository Repository { get; }
        void CloseDfileItemFromReceipt(ReceiptFacts facts);
        bool CloseDfileWithNoAction(DfileItem item, string resolution, string resolvedBy);
    }
}

namespace SCOUT.Core.Data
{
    public interface IDfileRepository
    {
        DfileItem GetUnResolvedItemBySerialNumber(IUnitOfWork uow, string serialNumber);
        ICollection<DfileItem> GetOpenDfileItemsByShopfloorline(IUnitOfWork uow, Shopfloorline shopfloorline);
        ICollection<DfileItem> GetDfileItemsByCritieria(IUnitOfWork uow, string criteria);
        ICollection<DfileItem> GetResolvedItemsByShopfloorline(IUnitOfWork uow, Shopfloorline shopfloorline);
        DfileItem GetResolvedItemBySerialNumber(IUnitOfWork uow, string serialNumber);
        ICollection<DfileItem> GetActiveDfileItemsByIncomingOrder(IUnitOfWork uow, int incomingOrderId);
    }
}
   