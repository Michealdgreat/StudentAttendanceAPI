namespace StuAttendanceAPI.Domain.UserAggregate
{

    /// <summary>
    /// user's information. Used in claims identity.
    /// </summary>
    public class UserInfo
    {
        public Guid UserId;
        public string? Email;

    }
}
