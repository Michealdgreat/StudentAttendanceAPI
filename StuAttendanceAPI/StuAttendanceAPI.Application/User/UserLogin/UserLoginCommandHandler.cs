using Application.User.Services;
using Common.Application.SecurityUtil;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StuAttendanceAPI.Application.User.UserLogin;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Application.User.UserLogin
{
    /// <summary>
    /// NOT USED, roll back to UserService class
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="tokenService"></param>
    public class UserLoginCommandHandler(IUserRepository repository, IConfiguration configuration) : IRequestHandler<UserLoginCommand, object>
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserRepository _repository = repository;


        public async Task<object> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var handler = new JwtSecurityTokenHandler();

                ArgumentNullException.ThrowIfNull(request.TagId, nameof(request.TagId));


                ///CHECK USER DETAILS
                var hashedTagId = Sha256Hasher.Hash(request.TagId!);

                var user = await FindUserByHashedPassword(hashedTagId);

                if (user == null)
                {
                    return HttpStatusCode.NotFound;
                }


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]!));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = GenerateClaims(user);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = credentials,
                    Issuer = _configuration["JwtConfig:Issuer"],
                    Audience = _configuration["JwtConfig:Audience"],
                };

                var token = handler.CreateToken(tokenDescriptor);
                string WriteToken = handler.WriteToken(token);

                return WriteToken;
            }
            catch (Exception)
            {

                throw;
            }


        }

        private async Task<UserDtoForClaims?> FindUserByHashedPassword(string Password)
        {
            try
            {
                var (emailQuery, emailParameter) = StuAttSqlFactory.GetUserByPasswordQuery(Password);
                return await _repository.LoadOneData<UserDtoForClaims, dynamic>(emailQuery, emailParameter);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static ClaimsIdentity GenerateClaims(UserDtoForClaims user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new (ClaimTypes.Role, user.Role!),
                new (ClaimTypes.Email, user.Email!),

            };

            return new ClaimsIdentity(claims);
        }
    }
}
