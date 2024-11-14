using Common.Application;
using MediatR;
using StuAttendanceAPI.Application.Course.Create;
using StuAttendanceAPI.Application.Course.Delete;
using StuAttendanceAPI.Application.Course.Update;
using StuAttendanceAPI.Domain.CourseAggregate;
using StuAttendanceAPI.Query.Course.GetCourseById;
using StuAttendanceAPI.Query.Course.GetCourseByName;
using StuAttendanceAPI.Query.Course.GetCoursesByTeacherId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.PresentationFacade.Course
{
    public class CourseFacade(IMediator mediator)
: ICourseFacade, ICourseFacade
    {
        private readonly IMediator _mediator = mediator;

        public async Task<OperationResult> CreateCourse(CreateCourseCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> UpdateCourse(UpdateCourseCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteCourse(DeleteCourseCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<CourseDto?> GetCourseById(Guid CourseId)
        {
            return await _mediator.Send(new GetCourseByIdQuery(CourseId));
        }

        public async Task<CourseDto?> GetCourseByName(string CourseName)
        {
            return await _mediator.Send(new GetCourseByNameQuery(CourseName));
        }

        public async Task<List<CourseDto>?> GetCoursesByTeacherId(Guid TeacherId)
        {
            return await _mediator.Send(new GetCoursesByTeacherIdQuery(TeacherId));
        }
    }
}
