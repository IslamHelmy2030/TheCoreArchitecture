using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Service.SecurityDto;

namespace TheCoreArchitecture.Domain.ISecurity
{
    public interface IAccountBusiness
    {
        Task<IRepositoryActionResult> InsertUser(RegisterParameter loginParameter);
        Task<IRepositoryActionResult> Login(LoginParameter loginParameter);
        Task Logout();
    }
}
