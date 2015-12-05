using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("station_materials_tasks"), MapInheritance(MapInheritanceType.OwnTable)]
    public class StationMaterialsTask : StationTaskBase
    {        
        private BomConfiguration m_configuration;

        public StationMaterialsTask(Session session) : base(session)
        {
                
        }

        [Persistent("bom_configuration_id")]
        public BomConfiguration Configuration
        {
            get { return m_configuration; }
            set
            {
                SetPropertyValue("Configuration", ref m_configuration, value);                
            }                        
        }

        public override string Description
        {
            get { return m_configuration == null ? "" : m_configuration.Description; }
        }

        public override string Category
        {
            get { return "Materials"; }
        }
    }
} 