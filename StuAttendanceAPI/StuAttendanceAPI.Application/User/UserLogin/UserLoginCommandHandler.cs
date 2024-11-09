using Application.User.Services;
using Common.Application.SecurityUtil;
using Common.Application.Validation;
using MediatR;
using StuAttendanceAPI.Application.User.UserLogin;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.UserLogin
{
    /// <summary>
    /// NOT USED, roll back to UserService class
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="tokenService"></param>
    public class UserLoginCommandHandler(IUserRepository repository, ITokenService tokenService) : IRequestHandler<UserLoginCommand, object>
    {

        private readonly ITokenService _tokenService = tokenService;
        private readonly IUserRepository _repository = repository;



        public async Task<object> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {

            var user = await FindUserByEmail(request.Email!) ?? throw new AuthenticationException("User not found");
            var hashedPassword = Sha256Hasher.Hash(request.Password!);

            if (user.Password != hashedPassword)
                throw new AuthenticationException("Password not correct");


            async Task<UserDtoForClaims?> FindUserByEmail(string email)
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

            var token = _tokenService.Generate(user);

            return new
            {
                Token = token,
                user.UserId,
                user.Password
            };

        }
    }
}
