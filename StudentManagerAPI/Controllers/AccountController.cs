using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StudentManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private AppSettings _appSettings;
        public AccountController(ILogger<AccountController> logger, AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {

                var UsersAuth = _appSettings.UserAuth.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.PassWord);
                if (UsersAuth == null)
                {                    
                    return Unauthorized("UserName or password is incorrect!");
                }

                var roles = GetRoles(UsersAuth);

                var tokenString = GenerateJSONWebToken(roles, UsersAuth.Expires);
                return Ok(new HttpResultObject(new { token = tokenString, expires = UsersAuth.Expires, email = UsersAuth.Email, user = UsersAuth.UserName }));                
            }
            catch (Exception)
            {
                return Unauthorized("Incorrect params!");
            }
        }

        private List<UserRolesObject> GetRoles(UserAuthObject user)
        {
            List<UserRolesObject> result = new List<UserRolesObject>();
            foreach (var i in _appSettings.PolicyAuth)
            {
                result.AddRange(i.UserRoles.Where(x => x.UserName == user.UserName).ToList());
            }
            return result;
        }

        private string GenerateJSONWebToken(List<UserRolesObject> userRoles, int Expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();

            List<string> roles = new List<string>();
            foreach (var item in userRoles)
            {
                roles.AddRange(item.Roles);
            }

            foreach (var item in roles.GroupBy(x => x).Select(y => y.Key))
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            claims.Add(new Claim(ClaimTypes.Name, userRoles[0].UserName));

            var token = new JwtSecurityToken(_appSettings.jwt.Issuer,
              null,
              claims.ToArray(),
              expires: DateTime.Now.AddMinutes(Expires),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
