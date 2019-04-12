using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Domain.ISecurity;
using TheCoreArchitecture.Service.SecurityDto;

namespace TheCoreArchitecture.Api.Base
{
    /// <inheritdoc />
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ApiBaseController : ControllerBase
    {
        /// <summary>
        /// Response Handler
        /// </summary>
        protected readonly IActionResultResponseHandler ResponseHandler;

        /// <summary>
        /// Token Business
        /// </summary>
        protected readonly ITokenBusiness TokenBusiness;

        /// <inheritdoc />
        public ApiBaseController(IActionResultResponseHandler responseHandler)
        {
            ResponseHandler = responseHandler;
        }

        /// <inheritdoc />
        public ApiBaseController(IActionResultResponseHandler responseHandler, ITokenBusiness tokenBusiness)
        {
            ResponseHandler = responseHandler;
            TokenBusiness = tokenBusiness;
        }

        /// <summary>
        /// Get User Data
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public IDecodingValidToken GetUserData()
        {
            return TokenBusiness.GetUserDataFromToken(this);
        }
    }
}
