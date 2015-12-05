namespace SCOUT.Core.Data
{
    public class RouteConfigMapper : IMapper<RouteConfiguration, RouteConfiguration>
    {
        public RouteConfiguration MapFrom(RouteConfiguration input)
        {
            RouteConfiguration config =Scout.Core.Data.CreateEntity<RouteConfiguration>(input.Session);
            config.Name = input.Name;

            foreach (RouteConfigurationPart part in input.ConfigurationParts)
            {
                config.ConfigurationParts.Add(new RouteConfigPartMapper().MapFrom(part));
            }

            return config;            
        }
    }
}