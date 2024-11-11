

namespace Application.User.Services
{
    public class UserDtoForClaims
    {

        /// <summary>
        /// User dto model.
        /// </summary>

        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

    }

}