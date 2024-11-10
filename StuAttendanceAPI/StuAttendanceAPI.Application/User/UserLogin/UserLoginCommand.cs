using Common.Application;
using MediatR;

namespace StuAttendanceAPI.Application.User.UserLogin
{
    public class UserLoginCommand : IRequest<object>
    {
        public string? TagId { set; get; }
    }
}
