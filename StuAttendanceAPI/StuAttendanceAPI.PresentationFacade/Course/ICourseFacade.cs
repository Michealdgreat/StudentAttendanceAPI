using Common.Application;
using StuAttendanceAPI.Application.Course.Create;
using StuAttendanceAPI.Application.Course.Delete;
using StuAttendanceAPI.Application.Course.Update;
using System;
using System.Linq;

namespace StuAttendanceAPI.PresentationFacade.Course
{
    public interface ICourseFacade
    {
        Task<OperationResult> CreateCourse(CreateCourseCommand command);
        Task<OperationResult> DeleteCourse(DeleteCourseCommand command);
        Task<OperationResult> UpdateCourse(UpdateCourseCommand command);
    }
}
