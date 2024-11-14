using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Course.GetCourseByName
{
    public class GetCourseByNameQueryHandler(ICourseRepository courseRepository) : IQueryHandler<GetCourseByNameQuery, CourseDto?>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<CourseDto?> Handle(GetCourseByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (ByNameQuery, ByNamePara) = StuAttSqlFactory.GetCourseByNameQuery(request.CourseName);

                var result = await _courseRepository.LoadOneData<CourseDto, dynamic>(ByNameQuery, ByNamePara);

                return result;
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
