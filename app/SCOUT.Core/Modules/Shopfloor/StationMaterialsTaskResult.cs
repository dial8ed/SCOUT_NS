using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("station_materials_task_results"), MapInheritance(MapInheritanceType.OwnTable)]
    public class StationMaterialsTaskResult : StationTaskResult
    {
        public StationMaterialsTaskResult(Session session) : base(session)
        {

        }

    }
}