using System.Threading.Tasks;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Domain.Dto;
using TheCoreArchitecture.Domain.Dto.Parameter;

namespace TheCoreArchitecture.Domain.IBusiness
{
    public interface ICountryBusiness
    {
        Task<IRepositoryActionResult> GetAllCountries();
        Task<IRepositoryActionResult> GetAllCountriesAreas();
        Task<IRepositoryActionResult> AddCountry(CountryAddDto country);
        Task<IRepositoryActionResult> UpdateCountry(CountryDto country);
    }
}
