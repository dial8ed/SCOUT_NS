using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_revisions")]
    public class PartRevision : VPObject
    {
        private Guid m_id;
        private Part m_part;
        private string m_revision;
        private DateTime m_revisionStartDate;
        private DateTime m_revisionEndDate;

        public PartRevision(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("part_id")]
        [Association("Part-Revisions")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("revision")]
        public string Revision
        {
            get { return m_revision; }
            set { SetPropertyValue("Revision", ref m_revision, value);} 
        }

        [Persistent("revision_start_date")]
        public DateTime RevisionStartDate
        {
            get { return m_revisionStartDate; }
            set { SetPropertyValue("RevisionStartDate", ref m_revisionStartDate, value); }
        }

        [Persistent("revision_end_date")]
        public DateTime RevisionEndDate
        {
            get { return m_revisionEndDate; }
            set { SetPropertyValue("RevisionEndDate", ref m_revisionEndDate, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}