using System;
using System.Net;
using TheCoreArchitecture.Common.APIUtilities;

namespace TheCoreArchitecture.Common.APIUtilities
{
    public class ActionResultResponseHandler : IActionResultResponseHandler
    {
        private readonly IRepositoryResult _repositoryResult;

        public ActionResultResponseHandler(IRepositoryResult repositoryResult)
        {
            _repositoryResult = repositoryResult;
        }
        public IRepositoryResult GetResult(IRepositoryActionResult repositoryActionResult)
        {
            _repositoryResult.Status = GetHttpStatusCode(repositoryActionResult.Status);
            _repositoryResult.Message = repositoryActionResult.Message;
            if (!HasError(repositoryActionResult.Exception))
            {
                _repositoryResult.Data = repositoryActionResult.Data;
            }

            return _repositoryResult;
        }

        private bool HasError(Exception exception)
        {
            return exception != null;
        }

        private HttpStatusCode GetHttpStatusCode(RepositoryActionStatus repositoryActionResult)
        {
            switch (repositoryActionResult)
            {
                case RepositoryActionStatus.Ok: _repositoryResult.Success = true; return HttpStatusCode.OK;

                case RepositoryActionStatus.Created: _repositoryResult.Success = true; return HttpStatusCode.Created;

                case RepositoryActionStatus.Updated: _repositoryResult.Success = true; return HttpStatusCode.Accepted;

                case RepositoryActionStatus.Deleted: _repositoryResult.Success = true; return HttpStatusCode.NoContent;

                case RepositoryActionStatus.NotFound: _repositoryResult.Success = true; return HttpStatusCode.NotFound;

                case RepositoryActionStatus.NothingModified: _repositoryResult.Success = false; return HttpStatusCode.NotModified;

                case RepositoryActionStatus.Error: _repositoryResult.Success = false; return HttpStatusCode.InternalServerError;

                case RepositoryActionStatus.BadRequest: _repositoryResult.Success = false; return HttpStatusCode.BadRequest;

                default: _repositoryResult.Success = false; return HttpStatusCode.BadGateway;
            }
        }

    }
}
