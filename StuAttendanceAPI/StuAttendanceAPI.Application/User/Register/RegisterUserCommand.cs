using Common.Application;
using StuAttendanceAPI.Domain.RoleAggregate;
using System.Net.Sockets;

namespace Application.User.Register
{
    public class RegisterUserCommand : IBaseCommand
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? TagId { get; set; }
        public Role UserRole { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}