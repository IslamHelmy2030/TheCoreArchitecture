using System.Collections.Generic;

namespace TheCoreArchitecture.Domain.Dto
{
    public class CountryAreasDto : CountryDto
    {
        public List<AreaDto> AreaDtos { get; set; }
    }
}