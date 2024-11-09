using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using StuAttendanceAPI.Infrastructure.Extension;
using StuAttendanceAPI.Domain.UserAggregate;

namespace StuAttendanceAPI.Base
{
    /// <summary>
    /// Base controller.
    /// All controllers should inherit from this class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        public UserInfo? UserInformation =>
            (User.Identity as ClaimsIdentity)?.GetUserInfo();
    }

}
