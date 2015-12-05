using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class BomConfigurationController : PersistentViewControllerBase<BomConfigurationModel,IBomConfigurationView>
    {
        public BomConfigurationController(BomConfigurationModel model, IBomConfigurationView view)
        {
            Initialize(model,view);
        }


        protected override void WireEvents()
        {
            m_viewEventsController.RegisterActionRequestHandler("save", View_Save);
            m_viewEventsController.RegisterActionRequestHandler("cancel", View_Cancel);

            m_viewEventsController.RegisterChangeRequestHandler<PartModel>(
                "PartModel", View_PartModelChanged);

            m_viewEventsController.RegisterChangeRequestHandler<Shopfloorline>("Shopfloorline", View_ShopfloorlineChanged);            
            m_viewEventsController.RegisterChangeRequestHandler<string>("Description", View_DescriptionChanged);

            View.OnAddComponentToConfigurationRequest += View_OnAddComponentToConfigurationRequest;
            View.OnRemoveBomConfigurationItemRequest += View_OnRemoveBomConfigurationItemRequest;

            Model.PropertyChanged += Model_PropertyChanged;
            
        }

        void View_OnRemoveBomConfigurationItemRequest(object sender, SingleChoiceActionRequestEventArgs<BomConfigurationItem> e)
        {
            Model.RemoveConfigurationItem(e.ActionItem);            
        }

        void View_OnAddComponentToConfigurationRequest(object sender, SingleChoiceActionRequestEventArgs<BomMasterComponent> e)
        {
            if(!Model.ContainsConfigurationForPart(e.ActionItem.Part))
            {
                Model.AddConfigurationItem(e.ActionItem);               
            }                
            else
                RaiseMessage("Part already exists.", UserMessageType.Error);                       
        }


        void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {            
            switch(e.PropertyName)
            {
                case("BomMaster"):
                    View.BomMaster = Model.BomMaster;
                    break;
            }
        }


        private void View_DescriptionChanged(object sender, PropertyChangeRequestEventArgs<string> e)
        {
            Model.Description = e.RequestedValue;
        }


        private void View_ShopfloorlineChanged(object sender, PropertyChangeRequestEventArgs<Shopfloorline> e)
        {
            Model.Shopfloorline = e.RequestedValue;
        }


        private void View_PartModelChanged(object sender, PropertyChangeRequestEventArgs<PartModel> e)
        {
            Model.PartModel = e.RequestedValue;            
        }


        private void View_Save(object sender, ActionRequestEventArgs args)
        {
            ModelValidator<BomConfigurationModel> validator =
                new BomConfigurationValidator(Model, MessageListener);

            View_Save(this, args, validator);                        
        }

        protected override void UnWireEvents()
        {
            m_viewEventsController.UnRegisterActionRequestHandler("save", View_Save);
            m_viewEventsController.UnRegisterActionRequestHandler("cancel", View_Cancel);

            m_viewEventsController.UnRegisterChangeRequestHandler<PartModel>(
                "PartModel", View_PartModelChanged);

            m_viewEventsController.UnRegisterChangeRequestHandler<Shopfloorline>("Shopfloorline", View_ShopfloorlineChanged);            
            m_viewEventsController.UnRegisterChangeRequestHandler<string>("Description", View_DescriptionChanged);
        }

        protected override void SetViewState()
        {
            View.Shopfloorlines = Model.Shopfloorlines;
            View.PartModel = Model.PartModel;            
            View.BomConfiguration = Model.Configuration;
            View.BomMaster = Model.BomMaster;
        }
    }
}