using AutoMapper;

namespace TheCoreArchitecture.Service.Mapping
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
