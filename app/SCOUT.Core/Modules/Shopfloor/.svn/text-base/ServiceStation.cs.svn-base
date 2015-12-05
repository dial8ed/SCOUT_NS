using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("service_stations")]
    public class ServiceStation : VPLiteObject
    {
        private int m_id = -1;
        private string m_name = "";
        private ServiceStationType m_type;
        private Shopfloorline m_shopfloorline;
        private Domain m_domain;
        private bool m_active = true;
               
        public ServiceStation(Session session) : base(session)
        {
        }

        [Key(AutoGenerate = true)]
        [Persistent("id")]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        [Persistent("type")]
        public ServiceStationType Type
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }

        [Persistent("shopfloorline")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline", ref m_shopfloorline, value); }
        }

        [Persistent("domain")]
        public Domain Domain
        {
            get { return m_domain; }
            set
            {
                SetPropertyValue("Domain", ref m_domain, value);
                if(m_domain != null && m_domain.Label.Length > 0)
                {
                    Shopfloorline = m_domain.Parent;
                }
            }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return m_active; }
            set { SetPropertyValue("Active", ref m_active, value); }
        }


        [NonPersistent]
        public string FullLocation
        {
            get { return m_domain.FullLocation + "-" + m_name;}
        }

        public override string ToString()
        {
            return m_name;
        }

        public override bool Equals(object obj)
        {
            ServiceStation station = obj as ServiceStation;
            
            if(station == null) return false;

            return station.Id == m_id;
        }
    }
}