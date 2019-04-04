using System.Net;
namespace TheCoreArchitecture.Common.APIUtilities
{
    public class RepositoryResult : IRepositoryResult
    {
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
