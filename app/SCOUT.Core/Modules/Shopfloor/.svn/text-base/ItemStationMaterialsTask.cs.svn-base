using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_station_material_tasks")]
    public class ItemStationMaterialsTask : VPLiteObject, IStationTask
    {
        private Guid m_id;
        private InventoryItem m_item;
        private RouteStationProcess m_process;
        private StationMaterialsTask m_task;
        private StationTaskResult m_result;

        public ItemStationMaterialsTask(Session session) : base(session)
        {

        }

        [Persistent("id"), Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [NonPersistent]
        public string Description
        {
            get { return m_task.Description; }
        }

        [NonPersistent]
        public string Category
        {
            get { return m_task.Category; }
        }

        [NonPersistent]
        public StationTaskOutcome Outcome
        {
            get { return Result.Outcome; }
        }

        public bool IsRequired
        {
            get { return m_task == null ? false : m_task.IsRequired; }
        }

        [Persistent("lotid"), Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        [Persistent("materials_task_id")]   
        public StationMaterialsTask Task
        {
            get { return m_task; }
            set { m_task = value; }
        }

        [Persistent("materials_result_id")]
        public StationTaskResult Result
        {
            get
            {
                if(m_result == null)
                   m_result = MapNewResult();

                return m_result;
            }
            set { m_result = value; }
        }

        [Persistent("process_id")]
        public RouteStationProcess RouteStationProcess
        {
            get { return m_process; }
            set { m_process = value; }
        }


        private StationTaskResult MapNewResult()
        {
            m_result = Scout.Core.Data.CreateEntity<StationTaskResult>(Session);
            m_result.Item = m_item;
            m_result.Task = m_task;
            return m_result;
        }
    }
}