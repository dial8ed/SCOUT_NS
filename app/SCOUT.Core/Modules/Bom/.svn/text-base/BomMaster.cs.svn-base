using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a master list of bom components by part model
    /// </summary>
    [Persistent("bom_masters")]
    public class BomMaster : VPObject
    {
        private int m_id;
        private PartModel m_partModel;

        public BomMaster(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }


        [Association("BomMaster-Components")]
        public XPCollection<BomMasterComponent> Components
        {
            get { return GetCollection<BomMasterComponent>("Components"); }
        }

        [Association("BomMaster-BomComponentCategories")]
        public XPCollection<BomComponentCategory> ComponentCategories
        {
            get { return GetCollection<BomComponentCategory>("ComponentCategories"); }
        }
      
        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}