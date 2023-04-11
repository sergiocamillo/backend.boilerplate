using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Smc.Application.Interfaces;
using Smc.Application.ViewModels;
using Smc.Infra.CrossCutting.Commun.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Smc.Domain.Models;
using Smc.Application.Services;
using Smc.Services.Api.Configurations;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Smc.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly AppSettings _appJwtSettings;
        private readonly IUserAppService _userAppService;
        
        public AccountController(
            IOptions<AppSettings> appJwtSettings,
            IUserAppService userAppService)
        {
            _appJwtSettings = appJwtSettings.Value;
            _userAppService = userAppService;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUserViewModel loginUser)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                var user = _userAppService.Login(loginUser);

                var fullJwt = GenerateJwt(user);

                var userToken = new {
                    id = user.Id,
                    email = user.Email,
                    token = fullJwt
                };

                return CustomResponse(userToken);
            }
            catch (RNException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateJwt(UserViewModel user)
        {
            var UserId = user.Id.ToString();
            ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(UserId, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, UserId),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email.ToString())
                   }
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appJwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _appJwtSettings.Issuer,
                Audience = _appJwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_appJwtSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
