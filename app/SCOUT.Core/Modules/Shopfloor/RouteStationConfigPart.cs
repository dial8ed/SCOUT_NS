using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_configuration_parts")]
    public class RouteConfigurationPart : VPObject
    {
        private int m_id;
        private RouteConfiguration m_config;
        private Part m_part;

        public RouteConfigurationPart(Session session)
            : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("config_id")]
        [Association("RouteConfiguration-Parts")]
        public RouteConfiguration Configuration
        {
            get { return m_config; }
            set { SetPropertyValue("Configuration", ref m_config, value); }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return m_part != null ? m_part.PartNumber : ""; }
            set
            {
                if(!IsLoading)
                    m_part = PartRepository.GetPartByPartNumber(Session, value);
            }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_part,"ValidPartReq", "Part number is not valid", "PartNumber");
        }
    }
}