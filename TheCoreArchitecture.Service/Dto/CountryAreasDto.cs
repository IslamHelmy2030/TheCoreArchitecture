using System.Collections.Generic;

namespace TheCoreArchitecture.Service.Dto
{
    public class CountryAreasDto : CountryDto
    {
        public List<AreaDto> Areas { get; set; }
    }
}