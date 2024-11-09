using Common.Query;
using StuAttendanceAPI.Query.User.DTO;

namespace StuAttendanceAPI.Query.User.GetList
{
    /// <summary>
    /// get list of all users
    /// </summary>
    public record GetUserListQuery : IQuery<List<UserDTO>>;
}
