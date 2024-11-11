using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Course.Delete
{
    public class DeleteCourseCommand : IBaseCommand
    {
        public Guid CourseId { get; set; }
        public UserInfo? CommandSender { get; set; }
    }
}
