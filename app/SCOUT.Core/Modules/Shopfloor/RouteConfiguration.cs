using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_configurations")]
    public class RouteConfiguration : VPObject
    {
        private int m_id;
        private string m_name;        

        public RouteConfiguration(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
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


        [Association("RouteConfiguration-Parts")]
        public XPCollection<RouteConfigurationPart> ConfigurationParts
        {
            get { return GetCollection<RouteConfigurationPart>("ConfigurationParts"); }
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

        public override string ToString()
        {
            return m_name;
        }

        public RouteConfiguration GetConfigurationFor(Part part)
        {

            foreach (RouteConfigurationPart configurationPart in ConfigurationParts)
            {
                if (configurationPart.Part.Equals(part))
                    return configurationPart.Configuration;
            }

            return null;
        }
    }
}