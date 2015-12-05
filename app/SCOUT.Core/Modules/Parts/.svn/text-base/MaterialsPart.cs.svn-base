using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("materials_parts")]
    public class MaterialsPart : VPObject
    {
        private int m_id;
        private Part m_parentPart;
        private string m_orderablePn = "";
        private string m_whereUsed = "";


        public MaterialsPart(Session session) : base(session)
        {
        }


        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("parent_part_id")]
        public Part ParentPart
        {
            get { return m_parentPart; }
            set { SetPropertyValue("ParentPart", ref m_parentPart, value); }
        }

        [Persistent("orderable_part_number")]
        public string OrderablePn
        {
            get { return m_orderablePn; }
            set { SetPropertyValue("OrderablePn", ref m_orderablePn, value); }
        }

        [Persistent("where_used")]
        public string WhereUsed
        {
            get { return m_whereUsed; }
            set { SetPropertyValue("WhereUsed", ref m_whereUsed, value); }
        }

        [Association("MaterialsPart-XrefPartNumbers")]
        public XPCollection<MaterialsPartXref> XrefPartNumbers
        {
            get { return GetCollection<MaterialsPartXref>("XrefPartNumbers"); }
        }

        [Association("MaterialsPart-Suppliers")]
        public XPCollection<MaterialsPartSupplier> Suppliers
        {
            get { return GetCollection<MaterialsPartSupplier>("Suppliers"); }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
        }
    }
}