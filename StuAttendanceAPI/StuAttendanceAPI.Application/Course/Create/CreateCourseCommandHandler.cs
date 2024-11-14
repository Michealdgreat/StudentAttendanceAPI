using Common.Application;
using StuAttendanceAPI.Domain.CourseAggregate;
using StuAttendanceAPI.Domain.RoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StuAttendanceAPI.Domain.CourseAggregate.Course;

namespace StuAttendanceAPI.Application.Course.Create
{
    public class CreateCourseCommandHandler(ICourseRepository courseRepository) : IBaseCommandHandler<CreateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<OperationResult> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request.CommandSender!.Role != Role.Teacher.ToString())
                {
                    return OperationResult.Error("NOT ALLOWED!. Only Teachers can create a course.");
                }

                var courseParameter = CourseFactory.CreateNew(request.CourseName!, request.CommandSender.UserId);


                await _courseRepository.SaveData<dynamic>("insert_course", new
                {
                    course_id = courseParameter.CourseId,
                    course_name = courseParameter.CourseName,
                    teacher_id = courseParameter.TeacherId,
                    created_at = DateTime.Now
                });

                return OperationResult.Success();
            }
            catch (Exception)
            {

                return OperationResult.Error();
            }
        }
    }
}
