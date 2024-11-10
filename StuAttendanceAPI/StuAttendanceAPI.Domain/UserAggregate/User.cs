using Common.Domain.Exceptions;
using Common.Domain.Tools;
using StuAttendanceAPI.Domain.RoleAggregate;

namespace StuAttendanceAPI.Domain.UserAggregate
{
    /// <summary>
    /// User Domain Model.
    /// </summary>
    public class User
    {
        public Guid UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role UserRole { get; private set; }
        public string? AvatarUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }


        private User(Guid userId, string firstName, string lastName, string email, string password, Role role, string avatarUrl, DateTime createdAt)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserRole = role;
            AvatarUrl = avatarUrl;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Factory Method for user domain
        /// </summary>
        public static class UserFactory
        {
            public static User CreateNew(string firstName, string lastName, string email, string password, Role role, string? avatarUrl)
            {
                return new User(Guid.NewGuid(), firstName, lastName, email, password, role, avatarUrl!, DateTime.Now);
            }

            public static User UpdateExisting(Guid userId, string firstName, string lastName, string email, string password, Role role, string avatarUrl, DateTime createdAt)
            {
                return new User(userId, firstName, lastName, email, password, role, avatarUrl, createdAt);
            }

            public static User DeleteUser(User user)
            {

                return null!;
            }
        }
    }

}