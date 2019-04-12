using System.Security.Claims;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public class DecodingValidToken : IDecodingValidToken
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}