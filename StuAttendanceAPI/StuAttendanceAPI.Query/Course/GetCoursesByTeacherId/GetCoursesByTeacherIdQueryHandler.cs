using Common.Query;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Course.GetCoursesByTeacherId
{
    public class GetCoursesByTeacherIdQueryHandler(ICourseRepository courseRepository) : IQueryHandler<GetCoursesByTeacherIdQuery, List<CourseDto>?>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<List<CourseDto>?> Handle(GetCoursesByTeacherIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (byTeahcerIdQUery, ByTeahcerIdPara) = StuAttSqlFactory.GetCoursesByTeacherIdQuery(request.TeacherId);


                var result = await _courseRepository.LoadData<CourseDto, dynamic>(byTeahcerIdQUery, ByTeahcerIdPara);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
