using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("service_comm_components")]
    public class ServiceCommodityComponent : VPObject
    {
        private int m_id;
        private string m_component;
        private PartServiceCommodity m_serviceCommodity;

        public ServiceCommodityComponent(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("component")]
        public string Component
        {
            get { return m_component; }
            set { SetPropertyValue("Component", ref m_component, value); }
        }

        [Association("ServiceCommodity-Components")]
        [Persistent("service_comm_id")]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_serviceCommodity; }
            set { SetPropertyValue("ServiceCommodity", ref m_serviceCommodity, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotEmpty(m_component, "CompReq", "Component is required.", "Component");
        }

        public override string ToString()
        {
            return m_component;
        }
    }
}