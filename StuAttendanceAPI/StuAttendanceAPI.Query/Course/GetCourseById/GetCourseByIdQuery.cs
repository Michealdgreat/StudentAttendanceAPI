using Common.Query;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Course.GetCourseById
{
    public record GetCourseByIdQuery(Guid CourseId) : IQuery<CourseDto?>;

}

