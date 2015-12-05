namespace SCOUT.Core.Data
{
    public class RouteStationResultMapper : IMapper<RouteStationStep, RouteStationResult>
    {
        public RouteStationResult MapFrom(RouteStationStep input)
        {
            RouteStationResult stationResult = Scout.Core.Data.CreateEntity<RouteStationResult>(input.Session);
            stationResult.Step = input;
            return stationResult;            
        }
    }
}