using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_manufacturers")]
    public class PartManufacturer : VPObject
    {
        private int m_id;
        private string m_manf;

        public PartManufacturer(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("manufacturer")]
        public string Manufacturer
        {
            get { return m_manf; }
            set { SetPropertyValue("Manufacturer", ref m_manf, value); }
        }

        public override string ToString()
        {
            return m_manf;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}