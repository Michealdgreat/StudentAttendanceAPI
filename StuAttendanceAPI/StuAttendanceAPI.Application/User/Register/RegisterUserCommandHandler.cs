using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.Exceptions;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain;
using System;
using System.Net;
using StuAttendanceAPI.Domain.UserAggregate;
using StuAttendanceAPI.Domain.RoleAggregate;
using System.Xml.Linq;
using System.Data;

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
                var password = Sha256Hasher.Hash(request.TagId!);

                var (TagSqlQuery, TagIdParameters) = StuAttSqlFactory.GetUserByPasswordQuery(password);


                var checkUser = await _userRepository.LoadOneData<UserDto, dynamic>(TagSqlQuery, TagIdParameters);

                if (checkUser != null)
                {
                    return OperationResult.Error("User already exist");
                }


                var UserParameter = StuAttendanceAPI.Domain.UserAggregate.User.UserFactory.CreateNew(request.FirstName!, request.LastName!, request.Email!, password, request.UserRole, null);


                var result = await _userRepository.SaveData<dynamic>("insert_user", new
                {
                    user_id = UserParameter.UserId,
                    fname = UserParameter.FirstName,
                    lname = UserParameter.LastName,
                    email = UserParameter.Email,
                    role = UserParameter.UserRole.ToString(),
                    avatar_url = UserParameter.AvatarUrl,
                    user_password = UserParameter.Password,
                    created_at = UserParameter.CreatedAt
                });

                return OperationResult.Success();

            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }
        }
    }
}
