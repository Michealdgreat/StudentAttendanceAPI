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
            var nameClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            if (emailClaim == null || nameClaim == null || userIdClaim == null)
            {
                throw new Exception("Required claim is missing");
            }

            var userInfo = new UserInfo()
            {

                UserId = Guid.Parse(userIdClaim.Value),
                Email = emailClaim.Value
            };

            return userInfo;

        }
    }

}
