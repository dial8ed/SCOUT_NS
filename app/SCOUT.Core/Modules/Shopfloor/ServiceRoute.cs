using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("service_routes")]
    public class ServiceRoute : VPObject
    {
        private int m_id;
        private string m_name = "";
        private Shopfloorline m_shopfloorline;
        private bool m_active = true;
        private ReturnType m_returnType = ReturnType.NotDefined;

        public ServiceRoute(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
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

        [Persistent("sfl_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline", ref m_shopfloorline, value); }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return m_active; }
            set { SetPropertyValue("Active", ref m_active, value); }
        }


        [Persistent("return_type")]
        public ReturnType ReturnType
        {
            get { return m_returnType; }
            set { SetPropertyValue("ReturnType", ref m_returnType, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            if(IsLoading)
                return;

            Verify.IsTrue(m_name.Length > 0,"NameRequired", "Name is required", "Name");
            Verify.IsNotNull(m_shopfloorline, "sflReq", "Shopfloorline is required.", "Shopfloorline");
            Verify.IsNotNull(FirstStation(), "firstStationReq", "A first station is required.", "FirstStation");
        }
        
        [Association("Route-Stations")]
        public XPCollection<RouteStation> Stations
        {
            get { return GetCollection<RouteStation>("Stations"); }            
        }

        public void SetFirstStation(RouteStation station)
        {
            foreach (RouteStation routeStation in Stations)
            {
                routeStation.IsFirstStation = false;
            }
            station.IsFirstStation = true;
        }

        public RouteStation FirstStation()
        {
            foreach (RouteStation station in Stations)
            {
                if (station.IsFirstStation)
                    return station;
            }
            return null;
        }

        public bool IsTransitionStation(RouteStation station)
        {
            foreach (RouteStation routeStation in Stations)
            {
                foreach (StationOutcomeTransition transition in routeStation.OutcomeTransitions)
                {
                    RouteStation nextStation = transition.NextStation;
                    if (nextStation != null)
                    {
                        if (nextStation.Equals(station))
                            return true;
                    }
                }
            }

            return false;
        }

        public RouteStation StationExistsByName(ServiceStation station)
        {
            foreach(RouteStation routeStation in Stations)
            {
                if(routeStation.Name == station.Name)
                {
                    return routeStation;
                }                
            }
            return null;            
        }

        public XPCollection<RouteStation> IncludedStations
        {
            get
            {                
                BinaryOperator included = new BinaryOperator("Included", true);
                BinaryOperator parent = new BinaryOperator("ServiceRoute", this);
                GroupOperator criteria = new GroupOperator(included, parent);
                XPCollection<RouteStation> stations = 
                    new XPCollection<RouteStation>(Stations,criteria);

                stations.DisplayableProperties = "This;Name;StationType";
                return stations;    
            }
        }


        public List<RouteStation> ActiveStations()
        {
            return Stations.Where(s => s.Included).ToList();
        }

        public void AddStations(ICollection<ServiceStation> stations)
        {
            foreach (ServiceStation station in stations)
            { 
                if(StationExistsByName(station) == null)
                    Stations.Add(new RouteStationMapper().MapFrom(station));
            }
        }


        public RouteStationProcess CreateRouteStationProcess(RouteStation station, InventoryItem item)
        {
            RouteStationProcess process = Scout.Core.Data.CreateEntity<RouteStationProcess>(item.Session);
            process.Station = station;
            process.Item = item;
            item.CurrentProcess = process;
            process.ShopfloorProgram = item.ShopfloorProgram;
            return process;
        }

        public ServiceRoute Clone()
        {
          CloneIXPSimpleObjectHelper helper = 
              new CloneIXPSimpleObjectHelper(Session as XpoUnitOfWork, Scout.Core.Data.GetUnitOfWork());

            return helper.Clone(this);            
        }

        public override string ToString()
        {
            return m_name;
        }

        public RouteStationConfiguration GetConfigurationFor(RouteStation station,Part part)
        {
            return RoutingRepository.GetConfigurationFor(station, part);
        }
    }
}