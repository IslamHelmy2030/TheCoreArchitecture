using AutoMapper;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Common.UnitOfWork;

namespace TheCoreArchitecture.Service.Dto.Base
{
    public interface IBusinessBaseParameter<T> where T : class
    {
        IMapper Mapper { get; set; }
        IUnitOfWork<T> UnitOfWork { get; set; }
        IRepositoryActionResult RepositoryActionResult { get; set; }
    }
}
