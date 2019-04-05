using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheCoreArchitecture.Api.Base;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Domain.IBusiness;

namespace TheCoreArchitecture.Api.Controllers
{
    /// <inheritdoc />
    public class CountryController : ApiBaseController
    {
        private readonly ICountryBusiness _countryBusiness;

        /// <inheritdoc />
        public CountryController(IActionResultResponseHandler handler, ICountryBusiness countryBusiness) : base(handler)
        {
            _countryBusiness = countryBusiness;
        }

        /// <summary>
        /// Get All Countries
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCountries))]
        public async Task<IRepositoryResult> GetAllCountries()
        {
            var repositoryResult = await _countryBusiness.GetAllCountries();
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }

        /// <summary>
        /// Get All Countries Details
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCountriesDetails))]
        public async Task<IRepositoryResult> GetAllCountriesDetails()
        {
            var repositoryResult = await _countryBusiness.GetAllCountriesDetails();
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }
    }
}
