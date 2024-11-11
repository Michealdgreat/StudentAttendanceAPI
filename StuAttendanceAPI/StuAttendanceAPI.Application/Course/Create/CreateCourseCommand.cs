using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Course.Create
{
    public class CreateCourseCommand : IBaseCommand
    {
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public Guid TeacherId { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserInfo? CommandSender { get; set; }
    }
}
