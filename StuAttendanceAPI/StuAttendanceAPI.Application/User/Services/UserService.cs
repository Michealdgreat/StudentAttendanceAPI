using Common.Application.SecurityUtil;
using Common.Application.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.User.Services
{
    public class UserService(IUserRepository repository, IConfiguration configuration) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IConfiguration _configuration = configuration;

        /// <summary>
        /// JWT Token generation.
        /// Username, email, name and role are saved in context and retrieved from claims identity.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        public async Task<string> GenerateAToken(string email, string password)
        {
            var handler = new JwtSecurityTokenHandler();

            ArgumentNullException.ThrowIfNull(email, nameof(email));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            //var (emailQuery, emailParameter) = SqlQueryFactory.GetUserByEmailQuery(email);

            ///CHECK USER DETAILS
            var user = await FindUserByEmail(email) ?? throw new AuthenticationException("User not found");
            var hashedPassword = Sha256Hasher.Hash(password);

            if (user.Password != hashedPassword)
                throw new AuthenticationException("Password not correct");

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

        private async Task<UserDtoForClaims?> FindUserByEmail(string email)
        {
            try
            {
                var (emailQuery, emailParameter) = StuAttSqlFactory.GetUserByEmailQuery(email);
                return await _repository.LoadOneData<UserDtoForClaims, dynamic>(emailQuery, emailParameter);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while accessing the database.", ex);
            }
        }

        private static ClaimsIdentity GenerateClaims(UserDtoForClaims user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new (ClaimTypes.Email, user.Email!),

            };

            return new ClaimsIdentity(claims);
        }
    }
}