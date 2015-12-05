using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("material_warehouse_items")]
    public partial class MaterialWarehouseItem : VPObject, IMaterialItem
    {
        private Guid m_id;        
        private Domain m_domain;
        private Part m_part;
        private string m_location;
        private int m_qty;

        public MaterialWarehouseItem(Session session)
            : base(session)
        {
            m_id = new Guid();
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }
       
        [Persistent("domain_id")]
        public Domain Domain
        {
            get { return m_domain; }
            set { SetPropertyValue("Domain", ref m_domain, value); }
        }

        [NonPersistent]
        public Shopfloorline Shopfloorline
        {
            get { return m_domain != null ? m_domain.Parent : null ; }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("location")]
        public string RackLocation
        {
            get { return m_location; }
            set { SetPropertyValue("Location", ref m_location, value); }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set {SetPropertyValue("Qty", ref m_qty, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {

        }
    }
}