using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Create
{
    public class CreateAttendanceCommand : IBaseCommand
    {
        public Guid AttendanceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime SignInAt { get; set; }
        public DateTime SignOutAt { get; set; }
        public UserInfo? CommandSender { get; set; }

    }
}
