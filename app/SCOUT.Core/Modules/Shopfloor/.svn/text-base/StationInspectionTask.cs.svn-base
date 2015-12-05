using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("station_tasks"), MapInheritance(MapInheritanceType.ParentTable)]
    public class StationInspectionTask : StationTaskBase
    {
        public StationInspectionTask(Session session) : base(session)
        {
            Frequency = StationTaskFequency.AsNeeded;
        }

        public override string Category
        {
            get { return "Inspection"; }
        }
    }
}