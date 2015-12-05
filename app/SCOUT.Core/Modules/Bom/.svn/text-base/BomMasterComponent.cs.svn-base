using DevExpress.Xpo;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    [Persistent("bom_master_components")]
    public class BomMasterComponent : VPObject
    {
        private int m_id;
        private Part m_part;
        private BomComponentCategory m_category;
        private BomMaster m_bomMaster;
       

        public BomMasterComponent(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return m_part == null ? "" : m_part.PartNumber; }
            set 
            {
                if(!IsLoading)
                    Part = PartService.GetPartByPartNumber(Session, value);
            }
        }

        [NonPersistent]
        public string Description
        {
            get { return m_part == null ? "" : m_part.Description; } 
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("bom_category_id")]
        public BomComponentCategory Category
        {
            get { return m_category; }
            set { SetPropertyValue("Category", ref m_category, value); }
        }

        [Persistent("bom_master_id")]
        [Association("BomMaster-Components")]
        public BomMaster BomMaster
        {
            get { return m_bomMaster; }
            set { SetPropertyValue("BomMaster", ref m_bomMaster, value); }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_category, "CategoryRequired", "Category is required.", "Category");
        }
    }
    
}