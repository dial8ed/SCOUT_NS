using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public class StationMaterialsTaskModel : MaterialsConsumptionModel, IStationTaskModel
    {
        private readonly ItemStationMaterialsTask m_task;        
        private StationTaskResult m_taskResult;

        public StationMaterialsTaskModel(ItemStationMaterialsTask task) : 
            base(task.Task.Configuration)
        {
            m_task = task;                    
        }

        public void CompleteTask(StationTaskOutcome outcome, string comments)
        {            
            m_task.Result.Comments = comments;
            m_task.Result.Outcome = outcome;
            m_task.Result.Process = m_task.RouteStationProcess;
        }

        public StationTaskBase Task
        {
            get { return m_task.Task; }
        }

        public StationTaskResult Result
        {
            get { return m_taskResult; }
        }

        public void UndoCompleteTask(string message)
        {
            m_task.Result.Comments = message;
            m_task.Result.Outcome = StationTaskOutcome.NotPerformed;            
        }
    }

    public interface IStationTaskModel
    {
        StationTaskBase Task { get;}
        StationTaskResult Result { get;}
    }
}