using System.Collections.Generic;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface ICaptureService
    {        
        bool RunCaptureCheck(InventoryItem item, string transType);
        void RunInventoryCapture(InventoryCapture capture, InventoryItem item);
        IList<InventoryCapture> GetCaptures(InventoryItem item);        
        InventoryHold CreateHold(InventoryItem item, string reason);
        InventoryHold CreateHoldForMultipleCaptures(InventoryItem item, IList<InventoryCapture> captures);
        bool ReleaseHold(InventoryHold hold, Domain moveToDomain);
        void ExecuteMultipleHighPriorityCapture(InventoryCapture capture, InventoryItem item);
        ICaptureRepository Repository { get; }
        ModuleProvider Providers { get; }
    }
}

namespace SCOUT.Core.Data
{
    public interface ICaptureRepository
    {
        bool SaveCapture(InventoryCapture capture);
        ICollection<InventoryCapture> GetActiveCapturesForShopfloorline(Shopfloorline sfl);
        InventoryCaptureProperties GetCapturePropertiesFor(InventoryItem item);
        ICollection<InventoryHold> GetUnresolvedHoldsForCapture(InventoryCapture capture);
        ICollection<InventoryHold> GetHoldsByShopfloorline(Shopfloorline sfl);
        ICollection<InventoryHoldDetails> GetHoldsByCriteriaString(IUnitOfWork uow,string criteria);
        ICollection<InventoryCapture> GetCapturesFromCommaIdString(IUnitOfWork uow, string captureIds);     
    }
}
