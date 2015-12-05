using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class BomMasterController :
        PersistentViewControllerBase<BomMasterModel, IBomMasterView>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="view"></param>
        public BomMasterController(BomMasterModel model, IBomMasterView view)
        {
            Initialize(model, view);
        }


        /// <summary>
        /// Handles the property change events raised from the model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Model_PropertyChanged(object sender,
                                           System.ComponentModel.
                                               PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "PartModel":
                    View.PartModel = Model.PartModel;
                    View.BomConfigurations = Model.BomConfigurations;
                    break;

                case "BomMaster":
                    View.BomMasterComponents = Model.BomMasterComponents;
                    View.BomConfigurations = Model.BomConfigurations;
                    View.BomComponentCategories = Model.BomComponentCategories;
                    break;
            }
        }


        /// <summary>
        /// Handles the create new bom master action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Model_NewBomMaster(object sender, ActionRequestEventArgs e)
        {
            NewBomMasterValidator validator = new NewBomMasterValidator(Model,
                                                                        MessageListener);

            ActionService.RunAction(this, validator, Model.NewBomMaster);
        }


        /// <summary>
        /// Validates and runs the save action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void View_Save(object sender, ActionRequestEventArgs e)
        {
            // Create validator for save action
            SaveBomMasterValidator validator = new SaveBomMasterValidator(
                Model, MessageListener);

            // Push validator down to base for execution.
            base.View_Save(sender, e, validator);
        }


        protected override void SetViewState()
        {
            Model.PartModel = Model.PartModel;
        }


        protected override void WireEvents()
        {
            m_viewEventsController.RegisterActionRequestHandler("save",
                                                                View_Save);

            m_viewEventsController.RegisterActionRequestHandler("cancel",
                                                                View_Cancel);

            Model.PropertyChanged += Model_PropertyChanged;


            View.EditBomConfiguration += View_EditBomConfiguration;

            View.DeleteBomConfiguration += View_DeleteBomConfiguration;

            m_viewEventsController.RegisterActionRequestHandler(
                "new_bom_master", Model_NewBomMaster);

            m_viewEventsController.RegisterActionRequestHandler(
                "new_bom_configuration", Model_NewBomConfiguration);
            
        }

        void View_EditBomConfiguration(object sender, SingleChoiceActionRequestEventArgs<BomConfiguration> e)
        {
            View.ManageConfiguration(Model.GetBomConfiguration(e.ActionItem.Id));      
        }

        void View_DeleteBomConfiguration(object sender, SingleChoiceActionRequestEventArgs<BomConfiguration> e)
        {
            Model.DeleteBomConfiguration(e.ActionItem);
            RaiseMessage("Configuration Deleted.", UserMessageType.Information);
        }

        private void Model_NewBomConfiguration(object sender,
                                               ActionRequestEventArgs e)
        {
            View.ManageConfiguration(Model.NewBomConfiguration());
        }

        protected override void UnWireEvents()
        {
            m_viewEventsController.UnRegisterActionRequestHandler("save",
                                                                  View_Save);

            m_viewEventsController.UnRegisterActionRequestHandler("cancel",
                                                                  View_Cancel);

            Model.PropertyChanged -= Model_PropertyChanged;


            m_viewEventsController.UnRegisterActionRequestHandler(
                "new_bom_master", Model_NewBomMaster);


            m_viewEventsController.UnRegisterActionRequestHandler(
                "new_bom_configuration", Model_NewBomConfiguration);


           
        }
    }
}