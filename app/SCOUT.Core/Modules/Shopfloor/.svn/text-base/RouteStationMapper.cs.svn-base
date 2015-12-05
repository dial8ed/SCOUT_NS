namespace SCOUT.Core.Data
{
    public class RouteStationMapper : IMapper<ServiceStation,RouteStation>
    {
        public RouteStation MapFrom(ServiceStation input)
        {
            RouteStation station = 
                Scout.Core.Data.CreateEntity<RouteStation>(input.Session);
                                
            station.Station = input;
            return station;
        }
    }
}