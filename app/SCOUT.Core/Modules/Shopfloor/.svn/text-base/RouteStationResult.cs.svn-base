using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_results")]
    public class RouteStationResult : VPObject
    {
        private int m_id;
        protected RouteStationStep m_step;
        private string m_result = "";
        private RouteStationProcess m_process;
        private string m_machineName = "";
        private InventoryItem m_item;

        public RouteStationResult(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }
   
        [Persistent("step_id")]
        public RouteStationStep Step
        {
            get { return m_step; }
            set { SetPropertyValue("Step", ref m_step, value); }
        }

        [Persistent("result")]
        public string Result
        {
            get { return m_result; }
            set
            {
                // Do not set blank values.
                if(!string.IsNullOrEmpty(value))
                    SetPropertyValue("Result", ref m_result, value);
            }
        }

        [Persistent("station_process_id")]
        [Association("RouteStation-Results")]
        public RouteStationProcess Process
        {
            get { return m_process; }
            set { SetPropertyValue("Process", ref m_process, value); }
        }

        [Persistent("machine_name")]
        public string MachineName
        {
            get
            {
                if (m_machineName == "")
                    m_machineName = Security.UserSecurity.CurrentUser.MachineName;
                return m_machineName;
            }
            set { SetPropertyValue("MachineName", ref m_machineName, value); }
        }

        [Persistent("lotid"), Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }
    

        [NonPersistent]
        public StepResultValidationType ValidationType
        {
            get { return m_step.ValidationType; }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            //Verify.IsTrue(m_step.Required && m_result.Length > 0,"ResultRequired", m_step.DisplayPrompt + " is required.","Result");
        }

    }
}