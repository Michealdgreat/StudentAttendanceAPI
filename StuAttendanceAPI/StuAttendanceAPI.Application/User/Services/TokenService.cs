using Application.User.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace StuAttendanceAPI.Application.User.Services
{
    public class TokenService(IConfiguration configuration)
: ITokenService
    {
        //private readonly JwtSetting _jwtSetting = jwtSetting.Value;
        private readonly IConfiguration _configuration = configuration;

        public string Generate(UserDtoForClaims user)
        {
            var authClaims = new List<Claim>
                {

                    new ("userid", user.UserId.ToString()),
                    new (ClaimTypes.Email, user.Email!),
                    new ("jwtid", Guid.NewGuid().ToString()),
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}



