namespace SCOUT.Core.Data
{
    public class FailCodeCategoryMapper : IMapper<ServiceCodeCategory,RouteStationFailCategory>
    {
        public RouteStationFailCategory MapFrom(ServiceCodeCategory input)
        {
            RouteStationFailCategory routeStationFailCategory = 
               Scout.Core.Data.CreateEntity<RouteStationFailCategory>(input.Session);

            routeStationFailCategory.CodeCategory = input;
            return routeStationFailCategory;
        }
    }
}