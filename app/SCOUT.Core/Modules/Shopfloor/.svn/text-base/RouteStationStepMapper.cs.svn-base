namespace SCOUT.Core.Data
{
    public class RouteStationStepMapper : IMapper<RouteStationStep,RouteStationStep>
    {
        public RouteStationStep MapFrom(RouteStationStep input)
        {
            RouteStationStep step = Scout.Core.Data.CreateEntity<RouteStationStep>(input.Session);
            step.Active = input.Active;
            step.DisplayPrompt = input.DisplayPrompt;
            step.LimitToList = input.LimitToList;
            step.Required = input.Required;
            step.ResultList = input.ResultList;
            step.SeqNo = input.SeqNo;
            step.TaskType = input.TaskType;

            return step;            
        }
    }
}