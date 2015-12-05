using System.Collections.Generic;
using System.Drawing;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public interface IStationInspectionTaskView : IPassiveView
    {
        ServiceCode FailureCode { get; set;}
        string DamageType { get; set;}
        string DamageMethod { get; set;}
        string Comments { get; set;}
        Image Image { get; set;}
        RouteStationStep Step { get; set;}
        RouteStationProcess Process { set;}
        ICollection<ServiceCode> FailCodes { set; }
        ICollection<RouteStationStep> Steps { set; }
    }
}