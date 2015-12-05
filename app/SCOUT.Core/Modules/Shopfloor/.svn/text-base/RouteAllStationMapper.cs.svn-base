using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class RouteAllStationMapper: IMapper<XPCollection<ServiceStation>,XPCollection<RouteStation>>
    {
        public XPCollection<RouteStation> MapFrom(XPCollection<ServiceStation> input)
        {
            XPCollection<RouteStation> routeStations;
            routeStations = new XPCollection<RouteStation>(input.Session);
            
            foreach (ServiceStation station in input)
            {                          
                routeStations.Add(new RouteStationMapper().MapFrom(station)); 
            }

            return routeStations;
            
        }
    }
}