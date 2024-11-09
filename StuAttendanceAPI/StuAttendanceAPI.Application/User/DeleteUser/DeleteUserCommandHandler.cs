using Common.Application;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository userRepository) : IBaseCommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var (Query, Parameter) = StuAttSqlFactory.GetUserByIdQuery(request.CommandSender!.UserId);

                var user = await _userRepository.LoadOneData<UserDto, dynamic>(Query, Parameter);

                if (user == null || user.UserId != request.UserId)
                {
                    return OperationResult.Error("You are not Authorized to perform this operation.");
                }

                await _userRepository.DeleteData<dynamic>("delete_user", new { p_user_id = request.UserId });

            }
            catch (InvalidOperationException ex)
            {

                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success("User Account Deleted SUccessfully");
        }
    }
}
