using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SCOUT.Core.Data;
using SCOUT.Core.Modules.Materials;

namespace SCOUT.Core.Mvc
{
    public interface IStationTaskView : IPassiveView
    {
        event
            EventHandler
                <SingleChoiceActionRequestEventArgs<IStationTask>>
            RunTask;

        event
            EventHandler
                <SingleChoiceActionRequestEventArgs<StationInspectionTaskResult>
                    > DeleteInspectionResult;
        event
            EventHandler
                <SingleChoiceActionRequestEventArgs<StationInspectionTaskResult>
                    > EditInspectionResult;

       
        Collection<IStationTask> Tasks { set; }
       
        IPartsConsumptionView PartsConsumptionTaskView { get; }
        void ShowMaterialsTaskView();

        IStationInspectionTaskView InspectionTaskView { get;}
        void ShowInspectionTaskView();

        ICollection<StationInspectionTaskResult> InspectionResults { set; }

        RouteStationProcess Process { get;}
       
    }
}