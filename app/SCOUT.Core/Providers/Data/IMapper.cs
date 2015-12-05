namespace SCOUT.Core
{
    public interface IMapper<Input, Output>
    {
        Output MapFrom(Input input);
    }
}