using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public class StationInspectionTaskController : ViewControllerBase<StationInspectionTaskModel, IStationInspectionTaskView>
    {
        public StationInspectionTaskController(StationInspectionTaskModel model, IStationInspectionTaskView view)
        {
            Initialize(model,view);
            MapViewFromModel();
        }


        private void MapViewFromModel()
        {
            PropertyMapper<StationInspectionTaskModel,IStationInspectionTaskView> mapper
                = new PropertyMapper<StationInspectionTaskModel,IStationInspectionTaskView>();

            mapper.MapFrom(Model, View); 
        }


        protected override void WireEvents()
        {
            m_viewEventsController.ActionRequestEvents.RegisterAction("save", View_Save);     
            m_viewEventsController.ActionRequestEvents.RegisterAction("cancel", View_Cancel);
        }


        private void View_Cancel(object sender, ActionRequestEventArgs e)
        {
            View.Close();            
        }


        private void View_Save(object sender, ActionRequestEventArgs e)
        {
            MapModelFromView();

           if (ModelFieldsAreValid())
           {
               MapPersistentObject();                         
               View.Close();                             
           }               
        }


        private void MapPersistentObject()
        {
            PropertyMapper<StationInspectionTaskModel, StationInspectionTaskResult> mapper = 
                new PropertyMapper<StationInspectionTaskModel, StationInspectionTaskResult>();

            mapper.MapFrom(Model, Model.TaskResult);                               
        }


        private bool ModelFieldsAreValid()
        {
            StationInspectionTaskValidator validator = 
                new StationInspectionTaskValidator(Model, MessageListener);

            return validator.Validated();
        }


        private void MapModelFromView()
        {

              PropertyMapper<IStationInspectionTaskView, StationInspectionTaskModel> mapper
                = new PropertyMapper<IStationInspectionTaskView, StationInspectionTaskModel>();

            mapper.MapFrom(View, Model);            
        }


        protected override void UnWireEvents()
        {
            m_viewEventsController.ActionRequestEvents.UnRegisterAction("save");
            m_viewEventsController.ActionRequestEvents.UnRegisterAction("cancel");
        }


        protected override void SetViewState()
        {          
            View.FailCodes = Model.FailCodes;
            View.Steps = Model.Steps;            
        }
    }
}