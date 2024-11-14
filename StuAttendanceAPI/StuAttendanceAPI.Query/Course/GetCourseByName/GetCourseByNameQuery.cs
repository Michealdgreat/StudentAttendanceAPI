using Common.Query;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Course.GetCourseByName
{
    public record GetCourseByNameQuery(string CourseName) : IQuery<CourseDto?>;
}
