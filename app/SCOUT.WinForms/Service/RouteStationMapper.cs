using SCOUT.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class RouteStationMapper : IMapper<ServiceStation,RouteStation>
    {
        public RouteStation MapFrom(ServiceStation input)
        {
            RouteStation station = Scout.Core.Data.CreateEntity<RouteStation>(input.Session);
            station.Station = input;
            return station;
        }
    }
}