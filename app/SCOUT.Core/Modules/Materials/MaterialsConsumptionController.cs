using System.Collections.Generic;
using System.Data;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Materials;
using SCOUT.Core.Services;

namespace SCOUT.Core.Mvc
{
    public class MaterialsConsumptionController :
        PersistentViewControllerBase<MaterialsConsumptionModel, IPartsConsumptionView>
    {
        public MaterialsConsumptionController(MaterialsConsumptionModel model,
                                              IPartsConsumptionView view)
        {
            Initialize(model, view);
            PersistentController.OnLockingException +=
                PersistentController_OnLockingException;
        }
       
        protected virtual void View_Save(object sender, ActionRequestEventArgs args)
        {
            // Adds each configuration item to the consumption request list.
            AddConfigurationToConsumptionRequests(args);
                
            // Validate
            if(!CanSave())
            {
                args.Cancel = true;
                return;
            }
                
            DoConsumptionActions(args);

            // Persist
            base.View_Save(this, args);
        }


        protected bool CanSave()
        {          
            MaterialsConsumptionValidator validator =
                    new MaterialsConsumptionValidator(Model, MessageListener);

            return validator.IsValid();    
        }

        private void DoConsumptionActions(ActionRequestEventArgs args)
        {
            // Deduct the consumption qtys
            Model.RemoveConsumedQtys();

            // Write the consumption transactions
            WriteTransactions(Model.ConsumptionRequests);
        }


        private void AddConfigurationToConsumptionRequests(ActionRequestEventArgs args)
        {
            try
            {
                foreach (var p in Model.PartsToConsume)
                {
                    AddConsumptionRequest(p.Part, p.Qty);
                } 
            }
            catch (NoNullAllowedException ex)
            {
               RaiseMessage(ex.Message,UserMessageType.Error);
               args.Cancel = true;
            }
        }

        private void WriteTransactions(
            Dictionary<MaterialConsumableItem, int> dictionary)
        {
            foreach (KeyValuePair<MaterialConsumableItem, int> i in dictionary)
            {
                MaterialConsumableItem item = i.Key;
                int qty = i.Value;
                MaterialService.WriteConsumptionTransaction(item, qty,
                                                            Model.ConsumptionDescription, "");
            }
        }


        public void AddConsumptionRequest(Part part, int qty)
        {
            MaterialConsumableItem item =
                MaterialRepository.GetConsumableItemByPart(part.Session,part,
                                                           Model.Shopfloorline);

            if (item == null)
                throw new NoNullAllowedException("Part Number " +
                                                 part.PartNumber +
                                                 " was not found in the consumable materials inventory.");

            m_model.AddConsumptionRequest(item, qty);
        }


        private void PersistentController_OnLockingException(object sender,
                                                             LockingExceptionEventArgs
                                                                 e)
        {
            e.UnitOfWork.ReloadChangedObjects();
            View_Save();
        }


        protected override void WireEvents()
        {
            m_viewEventsController.RegisterActionRequestHandler("save", View_Save);
            m_viewEventsController.RegisterActionRequestHandler("cancel", View_Cancel);
            m_viewEventsController.RegisterActionRequestHandler("refresh_materials", View_RefreshMaterials);
        }


        private void View_RefreshMaterials(object sender, ActionRequestEventArgs e)
        {
            Model.RefreshConsumableMaterials();               
        }


        protected override void UnWireEvents()
        {
            m_viewEventsController.UnRegisterActionRequestHandler("save", View_Save);
            m_viewEventsController.UnRegisterActionRequestHandler("cancel", View_Cancel);
            m_viewEventsController.UnRegisterActionRequestHandler("refresh_materials", View_RefreshMaterials);
        }


        protected override void SetViewState()
        {
            View.SetState(Model.ConsumptionDescription, Model.PartsToConsume);
        }
    }
}