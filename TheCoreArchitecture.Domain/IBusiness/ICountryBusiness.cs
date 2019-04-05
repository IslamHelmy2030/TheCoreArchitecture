using System.Threading.Tasks;
using TheCoreArchitecture.Common.APIUtilities;

namespace TheCoreArchitecture.Domain.IBusiness
{
    public interface ICountryBusiness
    {
        Task<IRepositoryActionResult> GetAllCountries();
        Task<IRepositoryActionResult> GetAllCountriesDetails();
    }
}
