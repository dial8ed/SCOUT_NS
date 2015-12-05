using System.Collections.Generic;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("bom_configurations")]
    public class BomConfiguration : VPObject
    {
        private int m_id;
        private Shopfloorline m_shopfloorline;        
        private PartModel m_partModel;
        private string m_description;

        public BomConfiguration(Session session) : base(session)
        {

        }


        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("shopfloorline_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline", ref m_shopfloorline, value); }
        }

        [Persistent("part_model_id")]
        public PartModel PartModel
        {
            get { return m_partModel; }
            set { SetPropertyValue("PartModel", ref m_partModel, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("ConfigurationDescription", ref m_description, value); }
        }

        [Association("BomConfiguration-Items"),Aggregated()]
        public XPCollection<BomConfigurationItem> ConfigurationItems
        {
            get { return GetCollection<BomConfigurationItem>("ConfigurationItems"); }
        }

        public override string ToString()
        {
            return m_description;
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_shopfloorline,"ShopfloorlineReq", "Shopfloorline Required.","Shopfloorline");
            Verify.IsNotNull(m_partModel,"PartModelReq","Part Model is required.","PartModel");            
            Verify.IsFalse(string.IsNullOrEmpty(m_description),"ConfigurationDescriptionReq","Configuration Description is required","ConfigurationDescription");
        }
    }
}