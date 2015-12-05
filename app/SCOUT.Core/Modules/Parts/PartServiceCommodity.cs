using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("part_service_commodities")]
    public class PartServiceCommodity : VPLiteObject
    {
        private PartAttributesHeader m_attrHeader;
        private UnitConfigHeader m_configHeader;
        private int m_id;
        private string m_name;

        public PartServiceCommodity(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        [Association("ServiceCommodity-Codes")]
        public XPCollection<ServiceCode> ServiceCodes
        {
            get
            {
                XPCollection<ServiceCode> codes = GetCollection<ServiceCode>("ServiceCodes");
                codes.Filter = new BinaryOperator("Active", true);
                return codes;
            }
        }

        [Association("ServiceCommodity-Components")]
        public XPCollection<ServiceCommodityComponent> Components
        {
            get { return GetCollection<ServiceCommodityComponent>("Components"); }
        }

        [Association("ServiceCommodity-PartModels")]
        public XPCollection<PartModel> PartModels
        {
            get { return GetCollection<PartModel>("PartModels"); }
        }

        [Persistent("attr_header_id")]
        public PartAttributesHeader AttributesHeader
        {
            get { return m_attrHeader; }
            set { SetPropertyValue("AttributesHeader", ref m_attrHeader, value); }
        }

        [Persistent("config_header_id")]
        public UnitConfigHeader UnitConfigHeader
        {
            get { return m_configHeader; }
            set { SetPropertyValue("UnitConfigHeader", ref m_configHeader, value); }
        }

        public ICollection<ServiceCode> ServiceCodesByModel(PartModel model)
        {
            return PartRepository.GetFailCodesByModel(this, model);
        }

        public override string ToString()
        {
            return m_name;
        }

        public void CreateAttrHeader()
        {
            AttributesHeader = Scout.Core.Data.CreateEntity<PartAttributesHeader>(Session);
            AttributesHeader.PartServiceCommodity = this;
        }

        public void CreateConfigHeader()
        {
            UnitConfigHeader = Scout.Core.Data.CreateEntity<UnitConfigHeader>(Session);
            UnitConfigHeader.PartServiceCommodity = this;
        }
    }
}