using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("station_task_results")]
    public class StationTaskResult : VPObject
    {
        private int m_id;
        private StationTaskBase m_task;
        private StationTaskOutcome m_outcome = StationTaskOutcome.NotPerformed;
        private string m_comments;       
        private InventoryItem m_item;
        private RouteStationFailure m_failure;
        private RouteStationProcess m_process;
       
        public StationTaskResult(Session session) : base(session)
        {
        }


        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }       
        }

        [Persistent("lotid"), Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }

        [Persistent("task_id")]
        public StationTaskBase Task
        {
            get { return m_task; }
            set { SetPropertyValue("Task", ref m_task, value); }
        }

        [Persistent("task_outcome_id")]         
        public StationTaskOutcome Outcome
        {
            get { return m_outcome; }
            set { SetPropertyValue("Outcome", ref m_outcome, value); }
        }

        [Persistent("comments")]            
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }


        [Persistent("process_id")]
        public RouteStationProcess Process
        {
            get { return m_process; }
            set
            {
                SetPropertyValue("Process", ref m_process, value);                                   
            }
        }

        public override string ToString()
        {
            return m_outcome.ToString();
        }

        [Persistent("failure_id")]
        public RouteStationFailure Failure
        {
            get { return m_failure; }
            set { SetPropertyValue("Failure", ref m_failure, value); }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}