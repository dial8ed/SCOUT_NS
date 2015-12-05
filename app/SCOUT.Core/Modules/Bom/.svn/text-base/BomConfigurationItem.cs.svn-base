using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("bom_configuration_items")]
    public class BomConfigurationItem : VPObject
    {
        private int m_id;
        private BomConfiguration m_bomConfiguration;
        private BomMasterComponent m_bomComponent;
        private int m_qty = 0;
        private BomUsageAction m_usageAction =
            BomUsageAction.Install;


        public BomConfigurationItem(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }


        [Persistent("bom_configuration_id")]
        [Association("BomConfiguration-Items")]
        public BomConfiguration BomConfiguration
        {
            get { return m_bomConfiguration; }
            set { SetPropertyValue("BomConfiguration", ref m_bomConfiguration, value); }
        }

        [Persistent("bom_component_id")]
        public BomMasterComponent BomComponent
        {
            get { return m_bomComponent; }
            set { SetPropertyValue("BomComponent", ref m_bomComponent, value); }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { SetPropertyValue("Qty", ref m_qty, value); }
        }

        [Persistent("bom_usage_action")]
        public BomUsageAction UsageAction
        {
            get { return m_usageAction; }
            set { SetPropertyValue("UsageAction",ref m_usageAction, value); }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            if(IsDeleted)
                Verify.IsTrue(true, "QtyGreaterThanZero", "Qty must be greater than zero.", "Qty");
            else
                Verify.IsTrue(m_qty > 0,"QtyGreaterThanZero","Qty must be greater than zero.", "Qty");
            
        }
    }
}