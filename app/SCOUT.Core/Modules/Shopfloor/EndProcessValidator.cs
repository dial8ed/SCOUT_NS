using System.Collections.Generic;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    internal class EndProcessValidator : ValidatorBase
    {
        private RouteStationProcess m_process;

        public EndProcessValidator(RouteStationProcess process)
        {
            m_process = process;
        }

        public override void GetError()
        {
            if (!AllFailuresHaveRepairs(m_process)) return; 
        }

        private bool AllFailuresHaveRepairs(RouteStationProcess process)
        {
            ICollection<RouteStationFailure> failures = process.AllProcessFailures;

            if(failures.Count > 0)
            {
                foreach (RouteStationFailure failure in failures)
                {
                    if(failure.Repairs.Count == 0)
                    {
                        m_error = "This process cannot end until all failures have repairs.";
                        return false;                        
                    }                        
                }
            }

            return true;
        }
    }
}