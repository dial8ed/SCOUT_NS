using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("station_outcome_transitions")]
    public class StationOutcomeTransition : VPObject
    {
        private int m_id;
        private RouteStation m_station;
        private StationOutcome m_outcome;
        private RouteStation m_nextStation;
        private bool m_endProcessRoute;
        private bool m_forceFailClosure = false;
        private bool m_forceFailure = false;

        public StationOutcomeTransition(Session session) : base(session)
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
        
        [Persistent("route_station_id")]
        [Association("RouteStation-OutcomeTransitions")]
        public RouteStation Station
        {
            get { return m_station; }
            set { SetPropertyValue("Station", ref m_station, value); }
        }

        [Persistent("outcome_id")]
        public StationOutcome Outcome
        {
            get { return m_outcome; }
            set { SetPropertyValue("Outcome", ref m_outcome, value); }
        }

        [Persistent("next_station_id")]
        public RouteStation NextStation
        {
            get { return m_nextStation; }
            set
            {
                if(m_endProcessRoute)
                    value = null;

                SetPropertyValue("NextStation", ref m_nextStation, value);
            }
        }

        [Persistent("end_process_route")]
        public bool EndProcessRoute
        {
            get { return m_endProcessRoute; }
            set
            {
                SetPropertyValue("EndProcessRoute", ref m_endProcessRoute, value);
                if(m_endProcessRoute)
                {
                    NextStation = null;
                }
            }
        }

        [Persistent("force_fail_closure")]        
        public bool ForceFailClosure
        {
            get { return m_forceFailClosure; }
            set { SetPropertyValue("ForceFailureClosure", ref m_forceFailClosure, value); }
        }


        [Persistent("force_failure")]
        public bool ForceFailure
        {
            get { return m_forceFailure; }
            set { SetPropertyValue("ForceFailure", ref m_forceFailure, value); }
        }

        [NonPersistent]
        public string OutcomeValue
        {
            get {  return m_outcome == null ? "" : m_outcome.Label; }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            if(m_endProcessRoute != true)
            {
                Verify.IsNotNull(m_nextStation, "NextStationReq", "Next station is required for this outcome", "NextStation");                
            }            
        }
    }
}