using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Domain.CourseAggregate
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public Guid TeacherId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
