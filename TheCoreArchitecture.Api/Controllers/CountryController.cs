using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheCoreArchitecture.Api.Base;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Domain.Dto;
using TheCoreArchitecture.Domain.Dto.Parameter;
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
        [HttpGet(nameof(GetAllCountriesAreas))]
        public async Task<IRepositoryResult> GetAllCountriesAreas()
        {
            var repositoryResult = await _countryBusiness.GetAllCountriesAreas();
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }

        /// <summary>
        /// Add Country
        /// </summary>
        /// <param name="country">New Country Name</param>
        /// <returns></returns>
        [HttpPost(nameof(AddCountry))]
        public async Task<IRepositoryResult> AddCountry([FromBody]CountryAddDto country)
        {
            var repositoryResult = await _countryBusiness.AddCountry(country);
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }

        /// <summary>
        /// Add Country
        /// </summary>
        /// <param name="country">New Country Name</param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCountry))]
        public async Task<IRepositoryResult> UpdateCountry([FromBody]CountryDto country)
        {
            var repositoryResult = await _countryBusiness.UpdateCountry(country);
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }
    }
}
