using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("unit_config_headers")]
    public class UnitConfigHeader : VPObject
    {
        private string m_attr1 = ".";
        private string m_attr2 = ".";
        private string m_attr3 = ".";
        private string m_attr4 = ".";
        private string m_attr5 = ".";
        private string m_attr6 = ".";
        private string m_attr7 = ".";
        private string m_attr8 = ".";
        private string m_attr9 = ".";
        private string m_attr10 = ".";
        private int m_id;
        private PartServiceCommodity m_serviceCommodity;

        public UnitConfigHeader(Session session)
            : base(session)
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

        [Persistent("attr_1")]
        public string Attr1
        {
            get { return m_attr1; }
            set { SetPropertyValue("Attr1", ref m_attr1, value); }
        }

        [Persistent("attr_2")]
        public string Attr2
        {
            get { return m_attr2; }
            set { SetPropertyValue("Attr2", ref m_attr2, value); }
        }

        [Persistent("attr_3")]
        public string Attr3
        {
            get { return m_attr3; }
            set { SetPropertyValue("Attr3", ref m_attr3, value); }
        }

        [Persistent("attr_4")]
        public string Attr4
        {
            get { return m_attr4; }
            set { SetPropertyValue("Attr4", ref m_attr4, value); }
        }

        [Persistent("attr_5")]
        public string Attr5
        {
            get { return m_attr5; }
            set { SetPropertyValue("Attr5", ref m_attr5, value); }
        }

        [Persistent("attr_6")]
        public string Attr6
        {
            get { return m_attr6; }
            set { SetPropertyValue("Attr6", ref m_attr6, value); }
        }

        [Persistent("attr_7")]
        public string Attr7
        {
            get { return m_attr7; }
            set { SetPropertyValue("Attr7", ref m_attr7, value); }
        }

        [Persistent("attr_8")]
        public string Attr8
        {
            get { return m_attr8; }
            set { SetPropertyValue("Attr8", ref m_attr8, value); }
        }

        [Persistent("attr_9")]
        public string Attr9
        {
            get { return m_attr9; }
            set { SetPropertyValue("Attr9", ref m_attr9, value); }
        }

        [Persistent("attr_10")]
        public string Attr10
        {
            get { return m_attr10; }
            set { SetPropertyValue("Attr10", ref m_attr10, value); }
        }

        [Persistent("service_comm_id")]
        public PartServiceCommodity PartServiceCommodity
        {
            get { return m_serviceCommodity; }
            set { SetPropertyValue("PartServiceCommodity", ref m_serviceCommodity, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
        }
    }
}