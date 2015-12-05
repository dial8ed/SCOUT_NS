namespace SCOUT.Core.Data
{
    public class StationOutcomeTransitionValidator : ValidatorBase
    {
        private StationOutcomeTransition m_transition;
        private RouteStationProcess m_process;

        public StationOutcomeTransitionValidator(StationOutcomeTransition transition, RouteStationProcess process)
        {
            m_transition = transition;
            m_process = process;
        }

        public override void GetError()
        {
            if(m_transition.ForceFailure && m_process.Failures.Count == 0)
            {
                m_error = "This station requires at least one failure to be recorded";
                return;
            }

            if(m_transition.ForceFailClosure && m_process.HasOpenFailures())
            {
                m_error = "This outcome requires all failures to be closed.";
                return;
            }           
 
            if(m_transition.ForceFailure && m_process.Failures.Count == 0)
            {
                m_error = "This outcome requires at least one failure to be recorded.";
                return;
            }
        }
    }
}