using Common.Application;
using StuAttendanceAPI.Application.Course.Create;
using StuAttendanceAPI.Application.Course.Delete;
using StuAttendanceAPI.Application.Course.Update;
using StuAttendanceAPI.Domain.CourseAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.PresentationFacade.Course
{
    public interface ICourseFacade
    {
        Task<OperationResult> CreateCourse(CreateCourseCommand command);
        Task<OperationResult> DeleteCourse(DeleteCourseCommand command);
        Task<CourseDto?> GetCourseById(Guid CourseId);
        Task<CourseDto?> GetCourseByName(string CourseName);
        Task<List<CourseDto>?> GetCoursesByTeacherId(Guid TeacherId);
        Task<OperationResult> UpdateCourse(UpdateCourseCommand command);
    }
}
