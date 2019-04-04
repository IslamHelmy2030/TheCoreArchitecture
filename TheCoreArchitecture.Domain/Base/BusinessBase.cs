using AutoMapper;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Common.UnitOfWork;

namespace TheCoreArchitecture.Domain.Base
{
    public class BusinessBase<T> where T : class
    {
        protected readonly IUnitOfWork<T> UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IRepositoryActionResult RepositoryActionResult;
        protected internal BusinessBase(IBusinessBaseParameter<T> businessBaseParameter)
        {
            UnitOfWork = businessBaseParameter.UnitOfWork;
            RepositoryActionResult = businessBaseParameter.RepositoryActionResult;
            Mapper = businessBaseParameter.Mapper;
        }
    }
}
