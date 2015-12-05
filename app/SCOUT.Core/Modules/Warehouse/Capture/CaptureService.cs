using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Data.Filtering;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;
using SCOUT.Core.Providers;
using SCOUT.Core.Services;


namespace SCOUT.Core.Data
{
    public enum HoldReleaseAction
    {
        Release = 0,
        ExecuteCaptureFromList = 1
    }

    /// <summary>
    /// Service
    /// </summary>
    public class CaptureService : ModuleService, ICaptureService
    {                        
        private ICaptureRepository m_repository;

        public CaptureService(IModule module): base(module)
        {
            m_repository = new CaptureRepository(Module);
        }

        public bool RunCaptureCheck(InventoryItem item, string transType)
        {
            Logging.Log("Running capture check for " + item.LotId, LogType.Information);

            IList<InventoryCapture> captures = GetCaptures(item);

            if (captures == null)
                return false;

            IList<InventoryCapture> highPriorities =
                new List<InventoryCapture>();

            foreach (InventoryCapture ic in captures)
            {
                if (ic.Priority == CapturePriority.High)
                    highPriorities.Add(ic);
            }
            
            // If only 1 high priority capture is found run it and return
            if (highPriorities.Count == 1)
            {
                RunInventoryCapture(highPriorities[0], item);
                return true;
            }
                
            // Send multiple high priority capture to resolution queue.
            if (highPriorities.Count > 1)
            {
                InventoryHold hold = CreateHoldForMultipleCaptures(item, highPriorities);
                UserInteraction.Dialog.ShowMessage
                    ("This unit should be put on hold for " + hold.Reason, UserMessageType.Warning, stubborn:true);
                return true;
            } 
                   
            // Process first normal priority capture
            RunInventoryCapture(captures[0], item);
            return true;
        }

        public void ExecuteMultipleHighPriorityCapture(InventoryCapture capture,InventoryItem item)
        {
            Logging.Log("Executing multiple high priority capture for " + item.LotId, LogType.Information);

            InventoryHold hold = item.Hold;
            hold.Resolution = "Multiple Capture Selected";
            hold.ResolutionDate = DateTime.Now;
            ReleaseHold(item.Hold, capture.HoldDomain);
            RunInventoryCapture(capture, item);
            UserInteraction.Dialog.ShowMessage("Capture Executed", UserMessageType.Information);
        }

        public void RunInventoryCapture(InventoryCapture capture, InventoryItem item)
        { 
            string captureReason = capture.Message;

            if(capture.Hold)
            {                        
                // Create Hold
                InventoryHold hold =  new InventoryHold(item, capture.Type);
                hold.Capture = capture;
                hold.AllowStationData = capture.AllowStationData;
                                                   
                // Create transaction  
                Transaction transaction = new CaptureTransactionMapper().MapFrom(hold); 
               
                if(capture.HoldStation != null)
                {                    
                    Scout.Core.Service<IShopfloorService>().MoveUnitToNewStation
                        (item.CurrentProcess, capture.HoldStation);
                }                             
            }

            // Apply Shopfloor Condition
            item.ShopfloorConditions = capture.ApplyCondition;

            UserInteraction.Dialog.ShowMessage("This unit is to be captured for: " + captureReason, UserMessageType.Warning);

            Scout.Core.Data.Save(item.Session);

            Logging.Log("Captured item " + item.SerialNumber + " for " + captureReason, LogType.Information);

        }

        public IList<InventoryCapture> GetCaptures(InventoryItem item)
        {
            // Do not check for captures for non-serialized product
            if (item.SerializedUnit == null)
                return null;

            // Get the capture properties for a inventory item
            // IE: Time In Field, Return Count, Etc.
            InventoryCaptureProperties props =
                Repository.GetCapturePropertiesFor(item);

            if (props == null)
            {                                
                Logging.Log
                    ("The capture properties are not available for this unit. The capture check will be bypassed.", LogType.Warning);
                return null;
            }
                
            // Get all the active captures for the shopfloorline the item is on
            ICollection<InventoryCapture> captures =                
                Repository.GetActiveCapturesForShopfloorline(props.Shopfloorline);

            List<InventoryCapture> matchingCaptures = 
                new List<InventoryCapture>();

            // Loop through the captures seeing if the criteria matches the items properties
            foreach (InventoryCapture capture in captures)
            {
                CriteriaOperator critieria = CriteriaOperator.Parse(capture.Criteria);
                if (critieria != null)
                {
                    if (props.Fit(critieria))
                        matchingCaptures.Add(capture);
                }
            }

            return matchingCaptures.Count > 0 ? matchingCaptures : null;            
        }

        public InventoryHold CreateHold(InventoryItem item, string reason)
        {
            InventoryHold hold = new InventoryHold(item, reason);
            return hold;
        }

        public InventoryHold CreateHoldForMultipleCaptures(InventoryItem item, IList<InventoryCapture> captures)
        {           
           if(captures.Count < 2)
               throw new NotSupportedException("The list of inventory captures must be more than 1.");
          
            InventoryHold hold = new InventoryHold(item, "MULTIPLE_CAPTURES");
            hold.ReleaseAction = HoldReleaseAction.ExecuteCaptureFromList;
                   
            StringBuilder builder = new StringBuilder();   
            foreach (InventoryCapture c in captures)
            {
                builder.Append(c.Id.ToString() + ",");
            }
          
            hold.MultipleCaptureIds = builder.ToString(0, builder.Length - 1);

            Logging.Log("Creating multi hold capture for " + item.LotId, LogType.Information);

            Scout.Core.Data.Save(item.Session);

            return hold;
        }

        public bool ReleaseHold(InventoryHold hold, Domain moveToDomain)
        {
            if (!new HoldResolutionValidator(hold).Validated())
                return false;

            Logging.Log("Releasing hold [" + hold.Reason + "] for " + hold.Item.LotId, LogType.Information);

            if (moveToDomain == null)
                moveToDomain = hold.Item.Domain;

           // Transfer the item to the specified domain
            Scout.Core.Service<IInventoryService>()
                    .TransferItemToDomain(hold.Item, moveToDomain);

            InventoryItem item = hold.Item;

            // Write transaction
            Scout.Core.Service<ITransactionService>().CreateTransaction(
                "CAPRELEASE", item, item.Domain.FullLocation, moveToDomain.FullLocation, hold.Resolution, "");

            // Remove the hold from the item
            item.Hold = null;

            // Close the hold
            hold.Status = HoldStatus.Closed;

            UserInteraction.Dialog.ShowMessage("Hold Released", UserMessageType.Information);

            return true;
        }

        public ICaptureRepository Repository
        {
            get { return m_repository; }
        }
    }
}