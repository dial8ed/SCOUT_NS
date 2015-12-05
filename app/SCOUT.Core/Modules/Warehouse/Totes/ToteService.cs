using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.Core.Modules;

namespace SCOUT.Core.Services
{
    public class ToteService : ModuleService, IToteService
    {
        public ToteService(IModule module) : base(module)
        {
        }

        public void TransferToteToDomain(Tote tote, Domain domain)
        {
            tote.Domain = domain;
            
            foreach (InventoryItem item in tote.Contents)
            {
                item.ChangeDomain(domain);
            }            
        }

        public void TransferSelectedItemsToNewTote(List<InventoryItem> objects, Tote tote)
        {
            foreach (InventoryItem item in objects)
            {     
                Scout.Core.Service<IInventoryService>().AddItemToTote(tote, item);
            }            
        }

        public void PutSelectedItemsInLocation(List<InventoryItem> items, RackLocation location, bool removeFromTote)
        {
            foreach (InventoryItem item in items)
            {
                // Create putaway transaction
                string currentLocation = item.Domain.FullLocation;
                Scout.Core.Service<ITransactionService>().CreateTransaction(
                    "PUTAWAY",
                    item,
                    currentLocation,
                    location.FullLocation, "", "");

                // Update the inventory item's rack location
                item.LocatorLabel = location.FullLocation; 
 
                if(removeFromTote)
                    Scout.Core.Service<IInventoryService>().RemoveItemFromTote(item);

            }            
        }
    }
}