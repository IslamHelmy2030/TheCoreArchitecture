using System.Collections.Generic;

namespace TheCoreArchitecture.Service.Dto
{
    public class CountryDetailsDto : CountryDto
    {
        public List<AreaDto> AreaDtos { get; set; }
    }
}