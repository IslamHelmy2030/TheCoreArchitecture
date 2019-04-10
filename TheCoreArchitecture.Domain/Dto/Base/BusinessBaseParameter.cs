using AutoMapper;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Common.UnitOfWork;

namespace TheCoreArchitecture.Domain.Dto.Base
{
    public class BusinessBaseParameter<T> : IBusinessBaseParameter<T> where T : class
    {

        public BusinessBaseParameter(IMapper mapper, IUnitOfWork<T> unitOfWork, IRepositoryActionResult repositoryActionResult)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            RepositoryActionResult = repositoryActionResult;
        }

        public IMapper Mapper { get; set; }
        public IUnitOfWork<T> UnitOfWork { get; set; }
        public IRepositoryActionResult RepositoryActionResult { get; set; }
    }
}
