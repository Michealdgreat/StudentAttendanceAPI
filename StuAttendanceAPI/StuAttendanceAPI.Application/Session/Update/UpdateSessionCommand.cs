using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.Session.Update
{
    public class UpdateSessionCommand : IBaseCommand
    {
        public Guid SessionId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public string? Name { get; set; }
        public UserInfo? CommandSender { get; set; }

    }
}
