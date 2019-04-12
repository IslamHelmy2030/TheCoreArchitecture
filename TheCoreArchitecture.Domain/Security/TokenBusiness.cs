using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TheCoreArchitecture.Data.IdentityEntities;
using TheCoreArchitecture.Domain.ISecurity;
using TheCoreArchitecture.Service.SecurityDto;

namespace TheCoreArchitecture.Domain.Security
{
    public class TokenBusiness : ITokenBusiness
    {
        private readonly IConfiguration _config;
        private readonly IUserLoginReturn _userLoginReturn;
        private readonly IDecodingValidToken _decodingValidToken;

        public TokenBusiness(IConfiguration config, IUserLoginReturn userLoginReturn, IDecodingValidToken decodingValidToken)
        {
            _config = config;
            _userLoginReturn = userLoginReturn;
            _decodingValidToken = decodingValidToken;
        }

        public IUserLoginReturn GenerateJsonWebToken(ApplicationUser user)
        {
            var token = GetToken(user);

            _userLoginReturn.FirstName = user.FirstName;
            _userLoginReturn.LastName = user.LastName;
            _userLoginReturn.UserId = user.Id;

            _userLoginReturn.TokenValidTo = token.ValidTo;
            _userLoginReturn.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return _userLoginReturn;
        }

        public IDecodingValidToken GetUserDataFromToken(ControllerBase controller)
        {
            var hasValue = controller.Request.Headers.TryGetValue("Authorization", out var bearerToken);
            if (!hasValue) return null;
            var split = bearerToken.ToString().Split(' ');
            var token = split[1];
            var result = ValidateAndDecodeToken(token);
            return result;
        }

        private IDecodingValidToken ValidateAndDecodeToken(string jwtToken)
        {
            var validationParameters = TokenValidationParameters();
            var handler = new JwtSecurityTokenHandler();
            try
            {
                _decodingValidToken.ClaimsPrincipal = handler.ValidateToken(jwtToken, validationParameters, out var _);

                //_decodingValidToken.JwtSecurityToken = (JwtSecurityToken)rawValidatedToken;

                return _decodingValidToken;
            }
            catch (SecurityTokenValidationException stvex)
            {
                // The token failed validation!
                // TODO: Log it or display an error.
                throw new Exception($"Token failed validation: {stvex.Message}");
            }
            catch (ArgumentException argex)
            {
                // The token was not well-formed or was invalid for some other reason.
                // TODO: Log it or display an error.
                throw new Exception($"Token was invalid: {argex.Message}");
            }
        }

        private TokenValidationParameters TokenValidationParameters()
        {
            string secret = _config["Jwt:SigningKey"];
            var key = Encoding.ASCII.GetBytes(secret);
            return new TokenValidationParameters
            {
                // Clock skew compensates for server time drift.
                ClockSkew = TimeSpan.FromMinutes(5),
                // Specify the key used to sign the token:
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                RequireSignedTokens = true,
                // Ensure the token was issued by a trusted authorization server (default true):
                ValidIssuer = _config["Jwt:Issure"],
                ValidateIssuer = true,
                // Ensure the token audience matches our audience value (default true):
                ValidAudience = _config["Jwt:Audience"],
                ValidateAudience = true,
                // Ensure the token hasn't expired:
                RequireExpirationTime = true,
                ValidateLifetime = true,
            };
        }

        private JwtSecurityToken GetToken(ApplicationUser user)
        {
            var claims = GetClaims(user);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]));
            var expiryInMinutes = DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiryInMinutes"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _config["Jwt:Issure"], audience: _config["Jwt:Audience"],
                expires: expiryInMinutes, signingCredentials: credentials, claims: claims);
            return token;
        }

        private List<Claim> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim( JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName)
            };

            claims.AddRange(user.UserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Role.Name)));

            return claims;
        }

    }
}
