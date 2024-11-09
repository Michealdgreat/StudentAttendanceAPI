using Microsoft.Extensions.Configuration;
using StuAttendanceAPI.Domain.UserAggregate;
using StuAttendanceAPI.Infrastructure.Repositories.Base;

namespace StuAttendanceAPI.Infrastructure.Repositories
{
    /// <summary>
    /// user repository
    /// </summary>
    /// <param name="configuration"></param>
    public class UserRepository() : BaseRepository, IUserRepository
    {
    }
}