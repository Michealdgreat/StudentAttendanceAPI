using StuAttendanceAPI.Domain.RoleAggregate;

namespace StuAttendanceAPI.Query.User.DTO
{

    /// <summary>
    /// GET USER return model.
    /// </summary>
    public class UserDTO
    {
        public Guid UserId { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public Role UserRole { get; private set; }
        public string? AvatarUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}