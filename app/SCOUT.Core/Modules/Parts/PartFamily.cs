using System;
using System.Text;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_families")]
    public class PartFamily : VPObject
    {        
        private Guid m_id;
        private PartServiceCommodity m_serviceCommodity;
        private bool m_allowOutgoingOverride;
      
        public PartFamily(Session session) : base(session)
        {

        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("label")]
        public string Label
        {
            get
            {
                if (Members.Count > 0)
                    return GetFlattenedMembers();

                return "";
            }

            set { }
        }

        [Persistent("service_commodity_id")]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_serviceCommodity; }
            set { SetPropertyValue("ServiceCommodity", ref m_serviceCommodity, value); }
        }

        [Persistent("allow_outgoing_override")]
        public bool AllowOutgoingOverride
        {
            get { return m_allowOutgoingOverride; }
            set { SetPropertyValue("AllowOutgoingOverride", ref m_allowOutgoingOverride, value); }
        }


        public PartFamily AddMember(Part part)
        {
            if(new AddFamilyMemberValidator(this, part).Validated())
            {
            if(!ContainsPart(part))
                Members.Add(part);
                return this;                
            }

            return null;            
        }

        public void RemoveMember(Part member)
        {
            Members.Remove(member);            
        }

        [Association("PartFamily-Members")]
        public XPCollection<Part> Members
        {
            get { return GetCollection<Part>("Members"); }
        }

        private string GetFlattenedMembers()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Part member in Members)
            {
                builder.AppendFormat("{0},", member.PartNumber);
            }

            return builder.ToString(0, builder.Length - 1);
        }

        public Part TopLevelPart
        {
            get
            {
                if(IsLoading) return null;

                foreach (Part member in Members)
                {
                    if (member.IsTopLevel)
                        return member;
                }

                return null;
            }
        }

        public bool ContainsPart(Part part)
        {
            foreach (Part member in Members)
            {
                if(member.Equals(part))
                    return true;
            }

            return false;
        }
    }
}