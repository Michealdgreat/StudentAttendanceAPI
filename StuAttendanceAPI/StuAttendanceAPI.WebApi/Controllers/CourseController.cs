using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuAttendanceAPI.Application.Course.Create;
using StuAttendanceAPI.Application.Course.Delete;
using StuAttendanceAPI.Application.Course.Update;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
using StuAttendanceAPI.Base;
using StuAttendanceAPI.PresentationFacade.Course;

namespace StuAttendanceAPI.Controllers
{
    public class CourseController(ICourseFacade courseFacade) : ApiControllerBase
    {
        private readonly ICourseFacade _courseFacade = courseFacade;

        [Authorize]
        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse(CreateCourseCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _courseFacade.CreateCourse(command);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _courseFacade.UpdateCourse(command);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(DeleteCourseCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _courseFacade.DeleteCourse(command);

            return Ok(result);
        }
    }
}
