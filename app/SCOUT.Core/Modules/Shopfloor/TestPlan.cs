using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("service_test_plans")]
    public class TestPlan : VPLiteObject
    {
        private int m_id;
        private string m_revision = "";
        private string m_name = "";        
        private PartServiceCommodity m_serviceCommodity = null;
        private Shopfloorline m_shopfloorline = null;

        public TestPlan(Session session) : base(session)
        {
        }

        [Key(AutoGenerate = true)]
        [Persistent("id")]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("revision")]
        public string Revision
        {
            get { return m_revision; }
            set { SetPropertyValue("Revision", ref m_revision, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        [Persistent("sfl_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline", ref m_shopfloorline, value); }
        }

        [Persistent("commodity_id")]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_serviceCommodity; }
            set { SetPropertyValue("ServiceCommodity", ref m_serviceCommodity, value); }
        }

        [Association("TestPlan-Stations")]
        public XPCollection<ServiceStation> Stations
        {
            get { return GetCollection<ServiceStation>("Stations"); }            
        }
    }
}