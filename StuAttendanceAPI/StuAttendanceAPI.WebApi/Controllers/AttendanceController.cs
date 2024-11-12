using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuAttendanceAPI.Application.AttendanceRecord.Create;
using StuAttendanceAPI.Application.AttendanceRecord.Delete;
using StuAttendanceAPI.Application.AttendanceRecord.Update;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
using StuAttendanceAPI.Base;
using StuAttendanceAPI.PresentationFacade.Attendance;

namespace StuAttendanceAPI.Controllers
{
    public class AttendanceController(IAttendanceFacade attendanceFacade) : ApiControllerBase
    {
        private readonly IAttendanceFacade _attendanceFacade = attendanceFacade;

        [Authorize]
        [HttpPost("CreateAttendanceRecord")]
        public async Task<IActionResult> CreateAttendanceRecord(CreateAttendanceCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _attendanceFacade.CreateAttendanceRecord(command);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("UpdateAttendanceRecord")]
        public async Task<IActionResult> UpdateAttendanceRecord(UpdateAttendanceCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _attendanceFacade.UpdateAttendanceRecord(command);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteAttendanceRecord")]
        public async Task<IActionResult> DeleteAttendanceRecord(DeleteAttendanceCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _attendanceFacade.DeleteAttendanceRecord(command);

            return Ok(result);
        }
    }
}
