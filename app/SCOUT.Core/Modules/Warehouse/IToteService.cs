using System.Collections.Generic;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface IToteService
    {
        void TransferToteToDomain(Tote tote, Domain domain);
        void TransferSelectedItemsToNewTote(List<InventoryItem> objects, Tote tote);
        void PutSelectedItemsInLocation(List<InventoryItem> items, RackLocation location, bool removeFromTote);
    }
}