using Common.Query;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Course.GetCoursesByTeacherId
{
    public record GetCoursesByTeacherIdQuery(Guid TeacherId) : IQuery<List<CourseDto>?>;
}
