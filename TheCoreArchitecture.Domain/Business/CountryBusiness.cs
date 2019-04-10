using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Domain.Base;
using TheCoreArchitecture.Domain.IBusiness;
using TheCoreArchitecture.Domain.Dto;
using TheCoreArchitecture.Domain.Dto.Base;
using TheCoreArchitecture.Domain.Dto.Parameter;

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
                var countriesDtos = Mapper.Map<List<Country>, List<CountryDto>>(countries);
                return RepositoryActionResult.GetRepositoryActionResult(countriesDtos, RepositoryActionStatus.Ok);
            }
            catch (Exception e)
            {
                return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went error", status: RepositoryActionStatus.Error);
            }
        }

        public async Task<IRepositoryActionResult> GetAllCountriesAreas()
        {
            try
            {
                var countriesSource = await UnitOfWork.Repository.GetAll(country => country.Areas);
                var countries = countriesSource.ToList();
                if (!countries.Any())
                    return RepositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.NotFound,
                        message: "No Data");
                var countriesDetailsDtos = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryAreasDto>>(countries);
                return RepositoryActionResult.GetRepositoryActionResult(countriesDetailsDtos, RepositoryActionStatus.Ok);
            }
            catch (Exception e)
            {
                return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went error", status: RepositoryActionStatus.Error);
            }
        }

        public async Task<IRepositoryActionResult> AddCountry(CountryAddDto country)
        {
            try
            {
                if (country == null)
                    return RepositoryActionResult.GetRepositoryActionResult(message: "Invalid Data");
                var newCountry = Mapper.Map<CountryAddDto, Country>(country);
                var addedCountry = UnitOfWork.Repository.Add(newCountry);
                var isSaved = await UnitOfWork.SaveChanges() > 0;
                if (isSaved)
                    return RepositoryActionResult.GetRepositoryActionResult(result: addedCountry,
                        status: RepositoryActionStatus.Created, message: "Saved Successfully");
                return RepositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.NothingModified, message: "Save Failed");
            }
            catch (Exception e)
            {
                return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went error", status: RepositoryActionStatus.Error);
            }
        }

        public async Task<IRepositoryActionResult> UpdateCountry(CountryDto country)
        {
            try
            {
                if (country == null)
                    return RepositoryActionResult.GetRepositoryActionResult(message: "Invalid Data");
                var newCountry = Mapper.Map<CountryDto, Country>(country);
                UnitOfWork.Repository.Update(newCountry);
                var isSaved = await UnitOfWork.SaveChanges() > 0;
                if (isSaved)
                    return RepositoryActionResult.GetRepositoryActionResult(result: country,
                        status: RepositoryActionStatus.Updated, message: "Saved Successfully");
                return RepositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.NothingModified, message: "Save Failed");
            }
            catch (Exception e)
            {
                return RepositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went error", status: RepositoryActionStatus.Error);
            }
        }
    }
}
