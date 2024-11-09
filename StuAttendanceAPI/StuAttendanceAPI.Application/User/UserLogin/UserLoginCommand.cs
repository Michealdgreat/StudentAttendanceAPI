using Common.Application;
using MediatR;

namespace StuAttendanceAPI.Application.User.UserLogin
{
    public class UserLoginCommand : IRequest<object>
    {
        public string? Email { set; get; }
        public string? Password { set; get; }
    }
}
