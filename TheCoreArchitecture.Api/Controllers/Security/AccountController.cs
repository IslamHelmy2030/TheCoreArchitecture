using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheCoreArchitecture.Api.Base;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Domain.ISecurity;
using TheCoreArchitecture.Service.SecurityDto;

namespace TheCoreArchitecture.Api.Controllers.Security
{
    /// <inheritdoc />
    public class AccountController : ApiBaseController
    {
        private readonly IAccountBusiness _accountBusiness;

        /// <inheritdoc />
        public AccountController(IActionResultResponseHandler responseHandler, IAccountBusiness accountBusiness) : base(responseHandler)
        {
            _accountBusiness = accountBusiness;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost(nameof(Login))]
        [AllowAnonymous]
        public async Task<IRepositoryResult> Login(LoginParameter parameter)
        {
            var repositoryResult = await _accountBusiness.Login(parameter);
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }

        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost(nameof(Register))]
        [AllowAnonymous]
        public async Task<IRepositoryResult> Register(RegisterParameter parameter)
        {
            var repositoryResult = await _accountBusiness.InsertUser(parameter);
            var result = ResponseHandler.GetResult(repositoryResult);
            return result;
        }
    }
}
