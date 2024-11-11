using Common.Application;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.CourseAggregate;
using StuAttendanceAPI.Domain.RoleAggregate;
using System;
using System.Linq;
using System.Security.Cryptography;
using static StuAttendanceAPI.Domain.CourseAggregate.Course;

namespace StuAttendanceAPI.Application.Course.Update
{
    public class UpdateCourseCommandHandler(ICourseRepository courseRepository) : IBaseCommandHandler<UpdateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<OperationResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var (courseQuery, courseParameter) = StuAttSqlFactory.GetCourseByIdQuery(request.CourseId);

                var checkOwnerShip = await _courseRepository.LoadOneData<CourseDto, dynamic>(courseQuery, courseParameter);

                if (checkOwnerShip == null || checkOwnerShip.TeacherId != request.CommandSender!.UserId)
                {
                    return OperationResult.Error();
                }

                if (request.CommandSender!.Role != Role.Teacher.ToString())
                {
                    return OperationResult.Error("NOT ALLOWED!. Only Teachers can create a course.");
                }

                var courseParameters = CourseFactory.UpdateExisting(request.CourseId, request.CourseName!, request.TeacherId!, checkOwnerShip.CreatedAt);


                await _courseRepository.SaveData<dynamic>("update_course", new
                {
                    cid = courseParameters.CourseId,
                    course_name = courseParameters.CourseName,
                    teacher_id = courseParameters.TeacherId,
                    created_at = courseParameters.CreatedAt,


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
