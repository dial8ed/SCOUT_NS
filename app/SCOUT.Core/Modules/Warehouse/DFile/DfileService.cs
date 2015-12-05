using System;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;
using SCOUT.Core.Providers;

namespace SCOUT.Core.Services
{
    public class DfileService : ModuleService, IDfileService
    {
        private IDfileRepository m_repository;

        public DfileService(IModule module) : base(module)
        {
            m_repository = new DfileRepository(module);
        }

        public DfileItem CreateDfileItem(ReceiptFacts facts, string reason)
        {
            if(Repository.GetUnResolvedItemBySerialNumber
                (Data.GetUnitOfWork(), facts.SerialNumber) != null)
            {
                UserInteraction.Dialog.ShowMessage
                    ("This unit is on dfile and must be resolved before it can be received.", UserMessageType.Error, stubborn:true);

                return null;
            }

            Logging.Log("Creating dfile for " + facts.SerialNumber, LogType.Information);

            DfileItem dfileItem = new DfileItem(Data.GetUnitOfWork())
                       {
                           ShopfloorlineId = facts.PurchaseOrder.Shopfloorline.Id,
                           IncomingOrderId = facts.PurchaseOrder.Order.Id,
                           PartId = facts.Part.Id,
                           SerialNumber = facts.SerialNumber,
                           Reason = reason,
                           Comments = facts.Comments,
                           LineItemIdentifier = facts.LineItemIdentifier
                       };

            Scout.Core.Data.Save(dfileItem.Session);            
            return dfileItem;
        }

        public bool CloseDfileWithNoAction(DfileItem item, string resolution, string resolvedBy)
        {
            if(string.IsNullOrEmpty(resolution))
            {
                UserInteraction.Dialog.ShowMessage
                    ("Resolution is required to close this item with no action.", UserMessageType.Validation);
                return false;
            }

            IUnitOfWork uow = item.Session;
            item.Resolution = resolution;
            item.ResolvedBy = resolvedBy;
            item.Action = DfileAction.NoAction;
            item.Status = DfileStatus.Closed;

            try
            {
                Scout.Core.Data.Save(uow);
                UserInteraction.Dialog.ShowMessage("Dfile closed with no action.", UserMessageType.Information);
                return true;
            }
            catch (Exception ex)
            {
                 UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
                return false;
            }
        }

        public bool ResolveItem(DfileItem item, string resolution, 
            string resolvedBy, DfileAction action, Order actionOrder)
        {
            if (!new DfileResolutionValidator(resolution, action, actionOrder).Validated())
                return false;

            item.Resolution = resolution;
            item.ResolvedBy = resolvedBy;
            item.ActionOrder = actionOrder;
            item.Action = action;
            item.Status = DfileStatus.Resolved;

            try
            {
                Scout.Core.Data.Save(item.Session);
                UserInteraction.Dialog.ShowMessage("Dfile Resolved", UserMessageType.Information);
                return true;
            }
            catch (Exception ex)
            {
                UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Exception);
                Logging.Log(ex.Message, LogType.Exception);
                return false;
            }
        }

        public bool CloseItem(DfileItem item)
        {
            try
            {            
                item.Status = DfileStatus.Closed;
                Scout.Core.Data.Save(item.Session);
                UserInteraction.Dialog.ShowMessage("Dfile closed", UserMessageType.Information);
                return true;
            }
            catch (Exception ex)
            {
                UserInteraction.Dialog.ShowMessage("There was an error closing the dfile record for this unit. Error=" + ex.Message,UserMessageType.Exception);
                return false;
            }
        }
 
        public IDfileRepository Repository
        {
            get { return m_repository; }        
        }

        public void CloseDfileItemFromReceipt(ReceiptFacts facts)
        {
            IUnitOfWork uow = Scout.Core.Data.GetUnitOfWork();

            DfileItem item = Repository.GetResolvedItemBySerialNumber(uow, facts.SerialNumber);

            if (item != null && item.ActionOrder.Id == facts.PurchaseOrder.Order.Id)
            {
                CloseItem(item);
                facts.DisableDfileCheck = item.DisableDfileAtReceipt;

                Logging.Log("Closing dfile item for " + facts.SerialNumber, LogType.Information);
            } 
            else if(item != null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage
                    ("This dfile unit should be received against order" + item.ActionOrder.Id, 
                    UserMessageType.Error);    
            }
        }
    }
}