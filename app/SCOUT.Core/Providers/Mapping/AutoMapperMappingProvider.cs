using AutoMapper;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using StructureMap;

namespace SCOUT.Core.Providers.Mapping
{
    public class AutoMapperMappingProvider : IMappingProvider
    {
        public AutoMapperMappingProvider()
        {
            CreateMappings();
        }

        public void CreateMappings()
        {
            Mapper.CreateMap<ReplacementComponentFacts, RepairComponent>()
                .ConstructUsing(dest => new RepairComponent(dest.UnitOfWork as Session))
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdated, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Repair, opt => opt.Ignore())
                .ForMember(dest => dest.ConsumptionReversed, opt => opt.Ignore());

        }

        public void AssertConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        public IMapper<TSource, TDest> GetMapper<TSource, TDest>()
        {
            return ObjectFactory.GetInstance<IMapper<TSource, TDest>>();
        }

        public TTo Map<TFrom, TTo>(TFrom from)
        {
            return Mapper.Map<TFrom, TTo>(from);
        }

        public void DynamicMap<TFrom, TTo>(TFrom from, TTo to)
        {                       
            Mapper.DynamicMap<TFrom, TTo>(from, to);
        }


    }
}