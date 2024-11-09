using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.DeleteUser
{
    public class DeleteUserCommand : IBaseCommand
    {
        public Guid UserId { get; set; }
        public UserInfo? CommandSender { get; set; }
    }
}
