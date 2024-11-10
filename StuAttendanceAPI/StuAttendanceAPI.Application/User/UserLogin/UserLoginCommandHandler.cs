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
using System.Net;
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


            try
            {
                var hashedTagId = Sha256Hasher.Hash(request.TagId!);

                var user = await FindUserByHashedPassword(hashedTagId);

                if (user == null)
                {
                    return HttpStatusCode.NotFound;
                }



                async Task<UserDtoForClaims?> FindUserByHashedPassword(string Password)
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

                var token = _tokenService.Generate(user);

                return new
                {
                    Token = token,
                    user.UserId,
                    user.Email,
                    user.Password
                };

            }
            catch (Exception)
            {

                return HttpStatusCode.InternalServerError;

            }

        }
    }
}
