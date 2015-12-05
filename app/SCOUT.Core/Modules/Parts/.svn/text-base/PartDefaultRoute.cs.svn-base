using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("part_default_routes")]
    public class PartDefaultRoute : VPObject 
    {
        private int m_id;
        private Shopfloorline m_sfl;
        private ServiceRoute m_route;
        private Part m_part;

        public PartDefaultRoute(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("sfl_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_sfl; }
            set { SetPropertyValue("Shopfloorline", ref m_sfl, value); }
        }

        [Persistent("route_id")]
        public ServiceRoute Route
        {
            get { return m_route; }
            set { SetPropertyValue("Route", ref m_route, value); }
        }

        [Persistent("part_id")]
        [Association("Part-DefaultRoutes")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}