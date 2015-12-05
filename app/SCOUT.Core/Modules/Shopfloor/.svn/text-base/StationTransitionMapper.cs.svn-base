namespace SCOUT.Core.Data
{
    public class StationTransitionMapper : IMapper<StationOutcome, StationOutcomeTransition>
    {
        public StationOutcomeTransition MapFrom(StationOutcome input)
        {
            StationOutcomeTransition transition = Scout.Core.Data.CreateEntity<StationOutcomeTransition>(input.Session);
            transition.Outcome = input;
            return transition;
        }
    }
}