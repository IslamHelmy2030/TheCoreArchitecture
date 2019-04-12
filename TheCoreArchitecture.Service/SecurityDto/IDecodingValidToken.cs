using System.Security.Claims;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public interface IDecodingValidToken
    {
        ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
