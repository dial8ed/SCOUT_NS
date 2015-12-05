using System.ComponentModel;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("service_codes")]
    public class ServiceCode : VPObject
    {
        private ServiceCodeCategory m_category;
        private int m_id = 0;
        private string m_code = "";
        private string m_description = "";
        private ServiceCodeType m_type = ServiceCodeType.FAIL;
        private PartServiceCommodity m_serviceCommodity;
        private bool m_active = true;
        private PartModel m_model;
        private string m_groupText;
        private bool m_isGlobal;

        public ServiceCode(Session session) : base(session)
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

        [Persistent("category")]
        public ServiceCodeCategory Category
        {
            get { return m_category; }
            set { SetPropertyValue("Category", ref m_category, value); }
        }

        [Persistent("code")]
        public string Code
        {
            get { return m_code; }
            set { SetPropertyValue("Code", ref m_code, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("type")]
        public ServiceCodeType Type
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }

        [Persistent("active"), DefaultValue(true)]
        public bool Active
        {
            get { return m_active;}
            set { SetPropertyValue("Active", ref m_active, value); }
        }

        [Association("ServiceCommodity-Codes")]
        [Persistent("commodity_id")]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_serviceCommodity; }
            set { SetPropertyValue("ServiceCommodity", ref m_serviceCommodity , value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotEmpty(m_code, "CodeReq", "Code is required.", "Code");
            Verify.IsNotNull(m_category, "CatReq", "Category is required.", "Category");
        }

        public override string ToString()
        {
            return string.Format("[{0}] - {1}", m_code, m_description);
        }

        [Persistent("model_id")]
        public PartModel Model
        {
            get { return m_model; }
            set { SetPropertyValue("Model", ref m_model, value); }
        }

        [Persistent("group_text")]
        public string GroupText
        {
            get { return m_groupText; }
            set { SetPropertyValue("GroupText", ref m_groupText, value); }
        }

        [Persistent("is_global")]
        public bool IsGlobal
        {
            get { return m_isGlobal; }
            set { SetPropertyValue("IsGlobal", ref m_isGlobal, value); }
        }
    }

    public enum ServiceCodeType
    {
        FAIL = 1
    }
}