using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pikia.Core.Entities.Indentity;
using Pikia.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<string> CreateToken(AppUser user , UserManager<AppUser> usermanager)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.GivenName , user.DisplayName)
            };
            var userRoles = await usermanager.GetRolesAsync(user);
            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));

            var token = new JwtSecurityToken(
                issuer : configuration["JWT:ValidIssuer"],
                audience : configuration["JWT:ValidAudience"],
                expires : DateTime.Now.AddDays(double.Parse(configuration["JWT:DurationInDays"])),
                claims : authClaims ,
                signingCredentials: new SigningCredentials(authKey ,SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
