using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("part_documents")]
    public class PartDocument : VPObject
    {
        private int m_id;
        private Document m_document;
        private Part m_part;   

        public PartDocument(Session session) : base(session)
        {
            Document = new Document(session);
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("Id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("document_id")]
        public Document Document
        {
            get { return m_document; }
            set { SetPropertyValue("Document", ref m_document, value); }
        }

        [Persistent("part_id")]
        [Association("Part-Documents")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [NonPersistent]
        public int ImageIndex
        {
            get { return 0; }
        }

        [NonPersistent]
        public string FilePath
        {
            get { return m_document.FilePath; }
            set { m_document.FilePath = value; }
        }

        [NonPersistent]
        public string Name
        {
            get { return m_document.Name; }
            set { m_document.Name = value; }
        }

        public override string ToString()
        {
            return m_document.Name;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}