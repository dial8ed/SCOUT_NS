namespace SCOUT.Core.Providers
{
    public interface IMappingProvider
    {
        TTo Map<TFrom, TTo>(TFrom from);
        void DynamicMap<TFrom, TTo>(TFrom from, TTo to);
        void CreateMappings();
        void AssertConfigurationIsValid();
        IMapper<TSource,TDest> GetMapper<TSource,TDest>();
    }
}