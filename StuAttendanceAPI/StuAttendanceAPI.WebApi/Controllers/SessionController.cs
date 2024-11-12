using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
using StuAttendanceAPI.Base;
using StuAttendanceAPI.PresentationFacade.Session;
using System.Net.WebSockets;

namespace StuAttendanceAPI.Controllers
{
    public class SessionController(ISessionFacade sessionFacade) : ApiControllerBase
    {
        private readonly ISessionFacade _sessionFacade = sessionFacade;

        [Authorize]
        [HttpPost("CreateSession")]
        public async Task<IActionResult> CreateSession(CreateSessionCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _sessionFacade.CreateSession(command);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("UpdateSession")]
        public async Task<IActionResult> UpdateSession(UpdateSessionCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _sessionFacade.UpdateSession(command);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteSession")]
        public async Task<IActionResult> DeleteSession(DeleteSessionCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _sessionFacade.DeleteSession(command);

            return Ok(result);
        }
    }
}
