using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("bom_component_categories")]
    public class BomComponentCategory : VPObject
    {
        private int m_id;
        private string m_category;        
        private BomMaster m_bomMaster;


        public BomComponentCategory(Session session) : base(session)
        {
        }


        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("category")]
        public string Category
        {
            get { return m_category; }
            set { SetPropertyValue("Category", ref m_category, value); }
        }

        [Persistent("bom_master_id")]
        [Association("BomMaster-BomComponentCategories")]
        public BomMaster BomMaster
        {
            get { return m_bomMaster; }
            set { SetPropertyValue("BomMaster", ref m_bomMaster, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

        public override string ToString()
        {
            return m_category;
        }
    }
}