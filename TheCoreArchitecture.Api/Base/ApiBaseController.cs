using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheCoreArchitecture.Common.APIUtilities;

namespace TheCoreArchitecture.Api.Base
{
    /// <inheritdoc />
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class ApiBaseController : ControllerBase
    {
        /// <summary>
        /// Response Handler
        /// </summary>
        protected readonly IActionResultResponseHandler ResponseHandler;

        /// <inheritdoc />
        public ApiBaseController(IActionResultResponseHandler responseHandler)
        {
            ResponseHandler = responseHandler;
        }
    }
}
