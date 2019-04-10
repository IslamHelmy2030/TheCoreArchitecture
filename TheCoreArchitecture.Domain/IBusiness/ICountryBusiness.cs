using System.Threading.Tasks;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Service.Dto;
using TheCoreArchitecture.Service.Dto.Parameter;

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
