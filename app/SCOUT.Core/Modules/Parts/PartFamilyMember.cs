using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_family_members")]
    public class PartFamilyMember : VPObject
    {
        private Guid m_id;
        private PartFamily m_family;
        private Part m_part;
        private bool m_isTopLevel;

        public PartFamilyMember(Session session) : base(session)
        {

        }

        [Persistent("id"), Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Association("PartFamily-Members")]
        [Persistent("family_id")]
        public PartFamily Family
        {
            get { return m_family; }
            set { SetPropertyValue("Family", ref m_family, value); }
        }

        [Persistent("part_id")]        
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [NonPersistent]
        public string PartNumber
        {
            get {
                return m_part == null ? "" : m_part.PartNumber; }
        }

        [NonPersistent]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_part.ServiceCommodity; }
        }

        [NonPersistent]
        public string Description
        {
            get { return m_part == null ? "" : m_part.Description; }
        }

        [NonPersistent]
        public bool IsTopLevel
        {
            get { return m_part == null ? false : m_part.IsTopLevel; }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {

        }

    }
}