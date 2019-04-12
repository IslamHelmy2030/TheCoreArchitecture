using Microsoft.AspNetCore.Mvc;
using TheCoreArchitecture.Data.IdentityEntities;
using TheCoreArchitecture.Service.SecurityDto;

namespace TheCoreArchitecture.Domain.ISecurity
{
    public interface ITokenBusiness
    {
        IUserLoginReturn GenerateJsonWebToken(ApplicationUser userInfo);
        IDecodingValidToken GetUserDataFromToken(ControllerBase controller);
    }
}
