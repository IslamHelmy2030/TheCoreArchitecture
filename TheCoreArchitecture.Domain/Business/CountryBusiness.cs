using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Domain.Base;
using TheCoreArchitecture.Domain.IBusiness;
using TheCoreArchitecture.Service.Dto;

namespace TheCoreArchitecture.Domain.Business
{
    public class CountryBusiness : BusinessBase<Country>, ICountryBusiness
    {
        public CountryBusiness(IBusinessBaseParameter<Country> businessBaseParameter) : base(businessBaseParameter)
        {
        }

        public async Task<IRepositoryActionResult> GetAllCountries()
        {
            try
            {
                var countriesSource = await UnitOfWork.Repository.GetAll();
                var countries = countriesSource.ToList();
                if (!countries.Any())
                    return RepositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.NotFound,
                        message: "No Data");
                var countriesDtos = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countries);
                return RepositoryActionResult.GetRepositoryActionResult(countriesDtos, RepositoryActionStatus.Ok);
            }
            catch (Exception e)
            {
                return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went error", status: RepositoryActionStatus.Error);
            }
        }

        public async Task<IRepositoryActionResult> GetAllCountriesDetails()
        {
            try
            {
                var countriesSource = await UnitOfWork.Repository.GetAll(country => country.Areas);
                var countries = countriesSource.ToList();
                if (!countries.Any())
                    return RepositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.NotFound,
                        message: "No Data");
                var countriesDetailsDtos = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDetailsDto>>(countries);
                return RepositoryActionResult.GetRepositoryActionResult(countriesDetailsDtos, RepositoryActionStatus.Ok);
            }
            catch (Exception e)
            {
                return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went error", status: RepositoryActionStatus.Error);
            }
        }
    }
}
