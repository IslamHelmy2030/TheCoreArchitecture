using AutoMapper;

namespace TheCoreArchitecture.Domain.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CountryMappingProfile();
            AreaMappingProfile();
        }
    }
}
