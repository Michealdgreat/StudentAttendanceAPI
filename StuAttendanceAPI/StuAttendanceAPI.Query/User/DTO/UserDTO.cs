using StuAttendanceAPI.Domain.RoleAggregate;

namespace StuAttendanceAPI.Query.User.DTO
{

    /// <summary>
    /// GET USER return model.
    /// </summary>
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}