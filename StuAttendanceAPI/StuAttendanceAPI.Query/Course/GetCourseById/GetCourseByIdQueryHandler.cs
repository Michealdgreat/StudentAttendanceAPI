using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.CourseAggregate;
using StuAttendanceAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Course.GetCourseById
{
    public class GetCourseByIdQueryHandler(ICourseRepository courseRepository) : IQueryHandler<GetCourseByIdQuery, CourseDto?>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (courseQuery, courseParameter) = StuAttSqlFactory.GetCourseByIdQuery(request.CourseId);

                var result = await _courseRepository.LoadOneData<CourseDto, dynamic>(courseQuery, courseParameter);

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
