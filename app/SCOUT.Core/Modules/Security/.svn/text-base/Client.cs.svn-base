using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{    
    [Persistent("clients")]
    public class Client : VPObject
    {
        private int m_id;
        private string m_userName;
        private string m_machineName;
        private string m_applicationVersion;
        private DateTime m_logInDate;
        private DateTime m_logOffDate;
        private string m_operatingSystem;


        public Client(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id",ref m_id, value); }
        }

        [Persistent("user_name")]
        public string UserName
        {
            get { return m_userName; }
            set { SetPropertyValue("UserName", ref m_userName, value); }
        }

        [Persistent("machine_name")]
        public string MachineName
        {
            get { return m_machineName; }
            set { SetPropertyValue("MachineName", ref m_machineName, value); }
        }

        [Persistent("application_version")]
        public string ApplicationVersion
        {
            get { return m_applicationVersion; }
            set { SetPropertyValue("ApplicationVersion", ref m_applicationVersion, value); }
        }

        [Persistent("log_in_date")]
        public DateTime LogInDate
        {
            get { return m_logInDate; }
            set { SetPropertyValue("LogInDate", ref m_logInDate, value); }
        }

        [Persistent("log_off_date")]
        public DateTime LogOffDate
        {
            get { return m_logOffDate; }
            set { SetPropertyValue("LogOffDate", ref m_logOffDate, value); }
        }

        [Persistent("operating_system")]
        public string OperatingSystem
        {
            get { return m_operatingSystem; }
            set { SetPropertyValue("OperatingSystem", ref m_operatingSystem, value); }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

    }
}