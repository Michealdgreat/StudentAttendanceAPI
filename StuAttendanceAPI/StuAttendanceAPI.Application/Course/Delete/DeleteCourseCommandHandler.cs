using Common.Application;
using StuAttendanceAPI.Domain.ContextHelper;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace StuAttendanceAPI.Application.Course.Delete
{
    public class DeleteCourseCommandHandler(ICourseRepository courseRepository) : IBaseCommandHandler<DeleteCourseCommand>
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<OperationResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var (courseQuery, courseParameter) = StuAttSqlFactory.GetCourseByIdQuery(request.CourseId);

            var checkOwnerShip = await _courseRepository.LoadOneData<CourseDto, dynamic>(courseQuery, courseParameter);

            if (checkOwnerShip == null || checkOwnerShip.TeacherId != request.CommandSender!.UserId)
            {
                return OperationResult.Error();
            }

            await _courseRepository.DeleteData<dynamic>("delete_course", new
            {
                cid = request.CourseId
            });


            return OperationResult.Success();
        }
    }
}
