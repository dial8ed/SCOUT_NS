using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_raw_report_queries")]
    public class RawReportQuery : VPLiteObject
    {
        private Guid m_id;
        private string m_routineName;
        private string m_description;
        private string m_displayName;

        public RawReportQuery(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("routine_name")]
        public string RoutineName
        {
            get { return m_routineName; }
            set { SetPropertyValue("RoutineName", ref m_routineName, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("display_name")]
        public string DisplayName
        {
            get { return m_displayName ?? m_routineName; }
            set { SetPropertyValue("DisplayName", ref m_displayName, value); }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}