using Common.Query;
using StuAttendanceAPI.Query.User.DTO;

namespace StuAttendanceAPI.Query.User.GetById
{
    /// <summary>
    /// Get user by id query
    /// </summary>
    /// <param name="UserId"></param>
    public record GetUserByIdQuery(Guid UserId) : IQuery<UserDTO>;
}