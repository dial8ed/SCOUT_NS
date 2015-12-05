using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_models")]
    public class PartModel : VPObject
    {
        private int m_id;
        private PartServiceCommodity m_serviceCommodity;
        private string m_model;
        private string m_description;
        private BomMaster m_bomMaster;
        
        public PartModel(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("service_commodity_id")]
        [Association("ServiceCommodity-PartModels")]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_serviceCommodity; }
            set { SetPropertyValue("ServiceCommodity", ref m_serviceCommodity, value); }
        }

        [Persistent("model")]
        public string Model
        {
            get { return m_model; }
            set { SetPropertyValue("Model", ref m_model, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("bom_master_id")]
        public BomMaster BomMaster
        {
            get { return m_bomMaster; }
            set { SetPropertyValue("BomMaster", ref m_bomMaster, value); }
        }

        public override string ToString()
        {
            return m_model;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}