using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("station_tasks")]
    public abstract class StationTaskBase : VPObject
    {
        private int m_id;
        private RouteStation m_routeStation;        
        private StationTaskFequency m_frequency = StationTaskFequency.OncePerReturn;
        private string m_description;
        private bool m_isRequired = false;
        private string m_programSpecifications;

        protected StationTaskBase(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("route_station_id")]
        public RouteStation RouteStation
        {
            get { return m_routeStation; }
            set { SetPropertyValue("RouteStation", ref m_routeStation, value); }
        }


        [Persistent("frequency_id")]
        public StationTaskFequency Frequency
        {
            get { return m_frequency; }
            set { SetPropertyValue("Frequency", ref m_frequency, value); }
        }

        [Persistent("is_required")]
        public bool IsRequired
        {
            get { return m_isRequired; }
            set { SetPropertyValue("IsRequired", ref m_isRequired, value); }
        }

        [Persistent("program_specifications")]
        public string ProgramSpecifications
        {
            get { return m_programSpecifications; }
            set { SetPropertyValue("ProgramSpecifications", ref m_programSpecifications, value); }
        }

        public bool ContainsProgramSpecification(string program)
        {
            if (string.IsNullOrEmpty(m_programSpecifications))
                return true;

            string[] programs =
                m_programSpecifications.Split(new string[] { "," }, StringSplitOptions.None);

            for (int i = 0; i < programs.Length; i++)
            {
                if (programs[i] == program)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Description;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

        [Persistent("description")]
        public virtual string Description
        {
            get { return m_description; }
        }

        public abstract string Category { get; }
       
    }
}