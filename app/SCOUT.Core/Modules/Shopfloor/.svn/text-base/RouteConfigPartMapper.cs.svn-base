namespace SCOUT.Core.Data
{
    public class RouteConfigPartMapper : IMapper<RouteConfigurationPart, RouteConfigurationPart>
    {
        public RouteConfigurationPart MapFrom(RouteConfigurationPart input)
        {
            RouteConfigurationPart configPart = Scout.Core.Data.CreateEntity<RouteConfigurationPart>(input.Session);
            configPart.Part = input.Part;
            configPart.PartNumber = input.PartNumber;
            return configPart;
        }
    }
}