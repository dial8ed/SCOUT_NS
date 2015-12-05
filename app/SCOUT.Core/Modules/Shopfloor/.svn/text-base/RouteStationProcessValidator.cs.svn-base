using SCOUT.Core.Utils;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Validates the elements of a <cref>RouteStationProcess</cref>
    /// </summary>
    public class RouteStationProcessValidator : ValidatorBase
    {
        private RouteStationProcess m_process;

        public RouteStationProcessValidator(RouteStationProcess process)
        {
            m_process = process;
        }

        public override void GetError()
        {          
            // Return the process error if it exists.
            if (!string.IsNullOrEmpty(m_process.Error))
            {
                m_error = m_process.Error;
                return;
            }
            
            if(ProcessHasDuplicateOpenFailures()) return;            
            if (!StationStepResultsAreValid()) return;         
            //if(HasInvalidRepairs())
            //    return;
        }


        private bool HasInvalidRepairs()
        {
            foreach (RouteStationFailure failure in m_process.Failures)
            {
                foreach (RouteStationRepair repair in failure.Repairs)
                {
                    if (repair.Repair != RepairAction.None && failure.Station.IsRepairComponentsRequired)
                    {
                        if (repair.Components.Count == 0)
                            m_error = "Repair action [ " + repair.Repair +
                                      " ] for failure [ " +
                                      repair.Failure.FailCode +
                                      " ] requires a component tracking entry.";
                                                            
                        return true;
                    }
                }
            }

            return false;            
        }


        /// <summary>
        /// Returns true if the process has duplicate open failures.
        /// </summary>
        /// <returns></returns>
        private bool ProcessHasDuplicateOpenFailures()
        {
            if (m_process.HasDuplicateOpenFailures())
            {
                m_error =
                    "Duplicate open failures are not allowed. Please delete the duplicates.";
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true if all results pass validation
        /// </summary>
        /// <returns></returns>
        private bool StationStepResultsAreValid()
        {
            if(m_process.StationOutcome == null)
                return true;

            // Yuk
            string processOutcome = m_process.StationOutcome.ToString();

            //Return true if the unit has not passed this station
            //Step results only need to be validated when the station outcome is PASS
            if(!processOutcome.Equals("PASS"))
                return true;

            // Iterate and validate all the route station results.       
            foreach (RouteStationResult result in m_process.Results)
            {                                               
                if (!ValidateStepResult(result)) return false;
            }

            return true;
        }

        // AOP: [TryCatchException]
        private bool ValidateStepResult(RouteStationResult result)
        {
            IValidator validator = StepResultValidatorFactory.CreateValidator(
                result.ValidationType, m_process.Item.Part.Attributes,
                result.Result);
                                                  
            // Validate
            var isValid = false;

            var error = ExecutionHelpers.TryCatchException(() => isValid = validator.Validated());

            if (error != null)
            {
                Error = error.Message;
                return false;
            }

            if (!isValid)
            {
                Error = validator.Error;
                return false;
            }

            return true;
        }
    }
}