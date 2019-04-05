using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Service.Dto;

namespace TheCoreArchitecture.Service.Mapping
{
    public partial class AutoMapperProfile
    {
        private void CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.CountryId, option => option.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, option => option.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Country, CountryDetailsDto>()
                .ForMember(dest => dest.CountryId, option => option.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, option => option.MapFrom(src => src.Name))
                .ForMember(dest => dest.AreaDtos, option => option.MapFrom(src => src.Areas))
                .ReverseMap();
        }
    }
}
