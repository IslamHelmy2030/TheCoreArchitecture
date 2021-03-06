﻿using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Domain.Dto;
using TheCoreArchitecture.Domain.Dto.Parameter;

namespace TheCoreArchitecture.Domain.Mapping
{
    public partial class AutoMapperProfile
    {
        private void CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.CountryId, option => option.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, option => option.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Country, CountryAreasDto>()
                .ForMember(dest => dest.CountryId, option => option.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, option => option.MapFrom(src => src.Name))
                .ForMember(dest => dest.AreaDtos, option => option.MapFrom(src => src.Areas))
                .ReverseMap();

            CreateMap<CountryAddDto, Country>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.CountryName));
        }
    }
}
