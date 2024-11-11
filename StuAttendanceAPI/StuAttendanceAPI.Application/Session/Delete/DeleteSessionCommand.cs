using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.Session.Delete
{
    public class DeleteSessionCommand : IBaseCommand
    {
        public Guid SessionId { get; set; }
        public UserInfo? CommandSender { get; set; }

    }
}
