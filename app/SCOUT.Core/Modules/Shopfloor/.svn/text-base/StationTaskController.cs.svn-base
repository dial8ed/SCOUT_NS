using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Materials;

namespace SCOUT.Core.Mvc
{
    public class StationTaskController :
        MvcControllerBase<StationTaskModel, IStationTaskView>
    {
        // Ctor
        public StationTaskController(StationTaskModel model,
                                     IStationTaskView view)
        {
            Initialize(model, view);
            MessageListener listener =
                new MessageListener(view.UserMessageOutputHost, this);
        }


        protected override void WireEvents()
        {
            View.RunTask += View_OnRunTask;
            View.DeleteInspectionResult += View_DeleteInspectionResult;
            View.EditInspectionResult += View_EditInspectionResult;
            m_viewEventsController.RegisterActionRequestHandler(
                "create_inspection_result", View_CreateInspectionResult);
        }

        /// <summary>
        /// Creates a inspection result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CreateInspectionResult(object sender,
                                                 ActionRequestEventArgs e)
        {
            StationInspectionTaskModel model =
                new StationInspectionTaskModel(Model.Process);

            IStationInspectionTaskView view = View.InspectionTaskView;

            StationInspectionTaskController controller =
                new StationInspectionTaskController(model, view);

            using(controller)
            {
                View.ShowInspectionTaskView();

                if (model.TaskResult != null &&
                    model.TaskResult.Outcome != StationTaskOutcome.NotPerformed)
                    Model.InspectionResults.Add(model.TaskResult);
            }
        }


        private void View_EditInspectionResult(object sender,
                                               SingleChoiceActionRequestEventArgs
                                                   <StationInspectionTaskResult>
                                                   e)
        {
            StationInspectionTaskModel model =
                new StationInspectionTaskModel(e.ActionItem);

            IStationInspectionTaskView view = View.InspectionTaskView;

            StationInspectionTaskController controller =
                new StationInspectionTaskController(model, view);

            View.ShowInspectionTaskView();
        }


        private void View_DeleteInspectionResult(object sender,
                                                 SingleChoiceActionRequestEventArgs
                                                     <
                                                     StationInspectionTaskResult
                                                     > e)
        {
            Model.InspectionResults.Remove(e.ActionItem);
            e.ActionItem.Delete();
        }


        private void View_OnRunTask(object sender,
                                    SingleChoiceActionRequestEventArgs
                                        <IStationTask> e)
        {
            if (e.ActionItem.Outcome != StationTaskOutcome.NotPerformed)
            {
                RaiseMessage("This task is complete.",
                             UserMessageType.Information);
                e.Cancel = true;
                return;
            }

            if (e.ActionItem as ItemStationMaterialsTask != null)
            {
                RunMaterialsTask(e.ActionItem as ItemStationMaterialsTask);
            }
        }


        private void RunMaterialsTask(ItemStationMaterialsTask itemTask)
        {
            IPartsConsumptionView view = View.PartsConsumptionTaskView;
            
            StationMaterialsTaskModel model =
                new StationMaterialsTaskModel(itemTask);

            StationMaterialsTaskController controller =
                new StationMaterialsTaskController(model, view);

            View.ShowMaterialsTaskView();
        }


        public bool HasOpenTasks()
        {
            foreach (IStationTask task in Model.Tasks)
            {
                if (task.IsRequired &&
                    task.Outcome == StationTaskOutcome.NotPerformed)
                    return true;
            }

            return false;
        }


        protected override void UnWireEvents()
        {
            View.RunTask -= View_OnRunTask;
            View.DeleteInspectionResult -= View_DeleteInspectionResult;
            View.EditInspectionResult -= View_EditInspectionResult;
            m_viewEventsController.UnRegisterActionRequestHandler(
                "create_inspection_result", View_CreateInspectionResult);            
        }

        protected override void SetViewState()
        {
            View.Tasks = Model.Tasks;
            View.InspectionResults = Model.InspectionResults;
        }
    }
}