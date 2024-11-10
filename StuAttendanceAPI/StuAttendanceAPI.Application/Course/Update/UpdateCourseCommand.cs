using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.Course.Update
{
    public class UpdateCourseCommand : IBaseCommand
    {
        public Guid CourseId { get; private set; }
        public string? CourseName { get; private set; }
        public Guid TeacherId { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
