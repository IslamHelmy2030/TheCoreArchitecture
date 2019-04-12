using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Data.IdentityEntities;
using TheCoreArchitecture.Domain.ISecurity;
using TheCoreArchitecture.Service.SecurityDto;

namespace TheCoreArchitecture.Domain.Security
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IRepositoryActionResult _repositoryActionResult;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenBusiness _tokenBusiness;

        public AccountBusiness(IRepositoryActionResult repositoryActionResult, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenBusiness tokenBusiness)
        {
            _repositoryActionResult = repositoryActionResult;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenBusiness = tokenBusiness;
        }

        public async Task<IRepositoryActionResult> InsertUser(RegisterParameter registerParameter)
        {
            try
            {
                if (registerParameter == null)
                {
                    return _repositoryActionResult.GetRepositoryActionResult(message: "Invalid Input Data", status: RepositoryActionStatus.Error);
                }
                var user = new ApplicationUser { UserName = registerParameter.UserName, Email = registerParameter.Email, FirstName = registerParameter.FirstName, LastName = registerParameter.LastName, SecurityStamp = new Guid().ToString() };

                var result = await _userManager.CreateAsync(user, registerParameter.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return _repositoryActionResult.GetRepositoryActionResult(user.UserName, status: RepositoryActionStatus.Ok, message: "Saved Successfully");
                }
                return _repositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.BadRequest, message: "Something went wrong");

            }
            catch (Exception e)
            {
                return _repositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went wrong", status: RepositoryActionStatus.Error);
            }
        }

        public async Task<IRepositoryActionResult> Login(LoginParameter loginParameter)
        {
            try
            {
                if (loginParameter == null)
                {
                    return _repositoryActionResult.GetRepositoryActionResult(message: "Something went wrong", status: RepositoryActionStatus.Error);
                }

                var user = await IsValidateUser(loginParameter);
                if (user == null)
                    return _repositoryActionResult.GetRepositoryActionResult(status: RepositoryActionStatus.BadRequest,
                        message: "Invalid Username Or Password");
                var userLoginReturn = _tokenBusiness.GenerateJsonWebToken(user);
                return _repositoryActionResult.GetRepositoryActionResult(userLoginReturn, status: RepositoryActionStatus.Ok, message: "Login Successfully");
            }
            catch (Exception e)
            {
                return _repositoryActionResult.GetRepositoryActionResult(exception: e, message: "Something went wrong", status: RepositoryActionStatus.Error);
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<ApplicationUser> IsValidateUser(LoginParameter loginParameter)
        {
            var user = await _userManager.FindByNameAsync(loginParameter.UserName);
            if (user == null) return null;
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginParameter.Password, false);
            return result.Succeeded ? user : null;
        }
    }
}
