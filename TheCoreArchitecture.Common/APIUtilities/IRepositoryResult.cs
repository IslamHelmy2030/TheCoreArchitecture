using System.Net;
namespace TheCoreArchitecture.Common.APIUtilities
{
    public interface IRepositoryResult
    {
        object Data { get; set; }
        HttpStatusCode Status { get; set; }
        string Message { get; set; }
        bool Success { get; set; }
    }
}
