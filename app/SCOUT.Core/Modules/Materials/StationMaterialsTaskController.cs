using SCOUT.Core.Data;
using SCOUT.Core.Modules.Materials;

namespace SCOUT.Core.Mvc
{
    public class StationMaterialsTaskController : MaterialsConsumptionController
    {
        private StationMaterialsTaskModel m_localModel;

        public StationMaterialsTaskController(StationMaterialsTaskModel model, IPartsConsumptionView view)
            : base(model, view)
        {
            m_localModel = model;
        }

        protected override void View_Save(object sender, ActionRequestEventArgs args)
        {              
            m_localModel.CompleteTask(StationTaskOutcome.Pass, "Task Completed.");

            base.View_Save(sender, args);

            // If there was an error performing the task then
            // undo the completion of the task.
            if (args.Cancel)
                m_localModel.UndoCompleteTask("Task un-done : " +
                                              args.UserMessage);

        }
    }
}