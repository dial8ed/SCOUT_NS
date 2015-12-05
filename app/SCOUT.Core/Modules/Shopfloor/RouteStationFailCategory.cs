using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_fail_categories")]
    public class RouteStationFailCategory : VPLiteObject
    {
        private int m_id;
        private ServiceCodeCategory m_codeCategory;
        private RouteStation m_routeStation;
        private bool m_active = true;

        public RouteStationFailCategory(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("category_id")]        
        public ServiceCodeCategory CodeCategory
        {
            get { return m_codeCategory; }
            set { SetPropertyValue("CodeCategory", ref m_codeCategory, value); }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return m_active;}
            set { SetPropertyValue("Active", ref m_active, value); }
        }

        [NonPersistent]
        public string Category
        {
            get { return m_codeCategory.Category; }
        }

        [Association("RouteStation-FailCategories")]
        [Persistent("route_station_id")]
        public RouteStation RouteStation
        {
            get { return m_routeStation;  }
            set { SetPropertyValue("RouteStation", ref m_routeStation, value); }
        }


        public override bool Equals(object obj)
        {

            RouteStationFailCategory category = obj as RouteStationFailCategory;
            if(category == null)
                return false;

            return category.CodeCategory.Equals(m_codeCategory);

        }
    }
}