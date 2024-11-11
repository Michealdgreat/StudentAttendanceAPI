using StuAttendanceAPI.Domain.UserAggregate;
using System.Security.Claims;

namespace StuAttendanceAPI.Infrastructure.Extension
{
    /// <summary>
    /// Extention method for claims identity.
    /// </summary>
    public static class TokenExtension
    {
        public static UserInfo GetUserInfo(this ClaimsIdentity claimsIdentity)
        {
            var emailClaim = claimsIdentity.FindFirst(ClaimTypes.Email);
            var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userRoleClaim = claimsIdentity.FindFirst(ClaimTypes.Role);



            if (emailClaim == null || userIdClaim == null)
            {
                throw new Exception("Required claim is missing");
            }

            var userInfo = new UserInfo()
            {

                UserId = Guid.Parse(userIdClaim.Value),
                Role = userRoleClaim!.Value,
                Email = emailClaim.Value
            };

            return userInfo;

        }
    }

}
