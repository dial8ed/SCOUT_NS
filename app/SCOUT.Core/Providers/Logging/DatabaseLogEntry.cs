using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Providers
{
    [Persistent("system_logs")]
    public class DatabaseLogEntry : VPObject
    {
        private int m_id;
        private string m_message;
        private LogType m_type;

        public DatabaseLogEntry(Session session) : base(session)
        {

        }

        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("message"), Size(4000)]
        public string Message
        {
            get { return m_message; }
            set { SetPropertyValue("Message", ref m_message, value); }
        }

        [Persistent("type")]
        public LogType Type
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            return;                
        }
    }
}