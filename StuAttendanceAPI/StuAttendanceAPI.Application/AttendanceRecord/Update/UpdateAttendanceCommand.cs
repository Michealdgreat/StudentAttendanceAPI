using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Update
{
    public class UpdateAttendanceCommand : IBaseCommand
    {
        public Guid AttendanceId { get; private set; }
        public Guid SessionId { get; private set; }
        public Guid StudentId { get; private set; }
        public DateTime SignInAt { get; private set; }
        public DateTime SignOutAt { get; private set; }
        public UserInfo? CommandSender { get; set; }

    }
}
