using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class StationInspectionTaskValidator :
        ModelValidator<StationInspectionTaskModel>
    {
        public StationInspectionTaskValidator(StationInspectionTaskModel model,
                                              MessageListener listener)
            : base(model, listener)
        {
        }


        public override void GetError()
        {
            if (string.IsNullOrEmpty(Model.DamageMethod))
            {
                m_error = "Damage Method is required.";
                return;
            }

            if (string.IsNullOrEmpty(Model.DamageType))
            {
                m_error = "Damage Type is required.";
                return;
            }

            //if (FailureExistsAndIsOpen())
            //{
            //    m_error =
            //        "The fail code selected already exists from a seperate entry.";
            //    return;
            //}
        }

        //private bool FailureExistsAndIsOpen()
        //{
        //    foreach (
        //        RouteStationFailure failure in Model.Process.AllProcessFailures)
        //    {
        //        if (failure.Repairs.Count == 0 &&
        //            failure.FailCode.Equals(Model.FailureCode))
        //            return true;
        //    }

        //    return false;
        //}
    }
}