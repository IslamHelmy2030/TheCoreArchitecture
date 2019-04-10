using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Domain.Dto;

namespace TheCoreArchitecture.Domain.Mapping
{
    public partial class AutoMapperProfile
    {
        private void AreaMappingProfile()
        {
            CreateMap<Area, AreaDto>()
                .ForMember(dest => dest.AreaId, option => option.MapFrom(src => src.Id))
                .ForMember(dest => dest.AreaName, option => option.MapFrom(src => src.Name))
                .ReverseMap();


        }
    }
}
