using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.Exceptions;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain;
using System;
using System.Net;
using StuAttendanceAPI.Domain.UserAggregate;

namespace Application.User.Register
{
    /// <summary>
    /// Dependencies injection
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="roleRepository"></param>
    /// <param name="subscriptionRepository"></param>
    public class RegisterUserCommandHandler(IUserRepository userRepository) : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        /// <summary>
        /// User registration command handler.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var (EmailSqlQuery, EmailParameters) = StuAttSqlFactory.GetUserByEmailQuery(request.Email);



                var checkUser = await _userRepository.LoadOneData<UserDto, dynamic>(EmailSqlQuery, EmailParameters);

                if (checkUser != null)
                {
                    return OperationResult.Error("User already exist");
                }

                var password = Sha256Hasher.Hash(request.Password);


                var UserParameter = StuAttendanceAPI.Domain.UserAggregate.User.UserFactory.CreateNew(new Guid(), request.FirstName, request.LastName, request.UserName, request.Email);


                await _userRepository.SaveData<dynamic>("insert_user", new
                {

                    p_email = UserParameter.Email,
                    p_password = UserParameter.Password,
                });

                return OperationResult.Success();
            }
            catch (InvalidDomainDataException ex)
            {
                return OperationResult.Error(ex.Message);
            }
        }
    }
}
