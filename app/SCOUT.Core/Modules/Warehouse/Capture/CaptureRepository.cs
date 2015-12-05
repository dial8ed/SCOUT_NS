using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Data
    /// </summary>
    public class CaptureRepository : ModuleService, ICaptureRepository
    {
        public CaptureRepository(IModule module)
            : base(module)
        {

        }

        public bool SaveCapture(InventoryCapture capture)
        {
            InventoryCaptureValidator validator = new InventoryCaptureValidator(capture);
            if (!validator.Validated())
                return false;

            Scout.Core.Data.Save(capture.Session);

            UserInteraction.Dialog.ShowMessage("Save Complete", UserMessageType.Information);

            return true;
        }

        //public ICollection<InventoryCapture> GetActiveCapturesForShopfloorline(Shopfloorline sfl)
        //{
        //    return CaptureRepository.GetActiveCapturesForShopfloorline(sfl);
        //}

        //public InventoryCaptureProperties GetCapturePropertiesFor(InventoryItem item)
        //{
        //    return CaptureRepository.GetCapturePropertiesFor(item);
        //}

        //public ICollection<InventoryHold> GetUnresolvedHoldsForCapture(InventoryCapture capture)
        //{
        //    return CaptureRepository.GetUnresolvedHoldsForCapture(capture);
        //}

        public ICollection<InventoryHold> GetHoldsByShopfloorline(Shopfloorline sfl)
        {
            return null;          
        }

        public ICollection<InventoryHoldDetails> GetHoldsByCriteriaString(IUnitOfWork uow, string criteria)
        {
            CriteriaOperator op1 = CriteriaOperator.Parse(criteria);
            return Repository
                .GetList<InventoryHoldDetails>(uow)
                .ByCriteria(op1);
        }

        public ICollection<InventoryCapture> GetCapturesFromCommaIdString(IUnitOfWork uow, string captureIds)
        {
            string[] ids = captureIds.Split(char.Parse(","));

            if (ids.Length == 0)
                return null;

            List<CriteriaOperator> idCriteria = new List<CriteriaOperator>();
            
            for (int i = 0; i < ids.Length; i++)
            {
                idCriteria.Add(new BinaryOperator("Id", ids[i]));
            }

            GroupOperator op1 = new GroupOperator(CriteriaOperator.Or(idCriteria));

            return Repository
                .GetList<InventoryCapture>(uow)
                .ByCriteria(op1);            
        }

        public ICollection<InventoryCapture> GetActiveCapturesForShopfloorline(Shopfloorline sfl)
        {
            BinaryOperator sflCriteria  = new BinaryOperator("Shopfloorline", sfl);
            BinaryOperator activeCriteria = new BinaryOperator("Active", true);
            GroupOperator criteria = new GroupOperator(sflCriteria,activeCriteria);
              
            return Repository
                .GetList<InventoryCapture>(sfl.Session)
                .ByCriteria(criteria);          
        }
        
        public InventoryCaptureProperties GetCapturePropertiesFor(InventoryItem item)
        {                                                  
            BinaryOperator criteria = new BinaryOperator("Item", item);
                return Repository
                    .Get<InventoryCaptureProperties>(item.Session)
                    .ByCriteria(criteria);            
        }
        
        public ICollection<InventoryHold> GetUnresolvedHoldsForCapture(InventoryCapture capture)
        {
            BinaryOperator crit1 = new BinaryOperator("Capture", capture);
            BinaryOperator crit2 = new BinaryOperator("Status", HoldStatus.Open);
            GroupOperator criteria = new GroupOperator(crit1,crit2);

            return Repository
                .GetList<InventoryHold>(capture.Session)
                .ByCriteria(criteria);
        }
    }
}