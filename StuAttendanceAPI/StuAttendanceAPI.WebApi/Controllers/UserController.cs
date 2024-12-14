using Application.User.DeleteUser;
using Application.User.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuAttendanceAPI.Application.User.UserLogin;
using StuAttendanceAPI.Base;
using StuAttendanceAPI.PresentationFacade.User;

namespace StuAttendanceAPI.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>


    public class UserController : ApiControllerBase
    {
        private readonly IUserFacade _userFacade;
        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        /// <summary>
        /// Get list of all registered users.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var users = await _userFacade.GetList();

            return Ok(users);
        }

        [Authorize]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            command.CommandSender = this.UserInformation;
            var result = await _userFacade.DeleteUser(command);

            return Ok(result);
        }

        /// <summary>
        /// Get user by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var user = await _userFacade.GetById(Id);

            return Ok(user);
        }


        /// <summary>
        /// Get user by TagId.
        /// </summary>
        /// <param name="TagId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetByTagId")]
        public async Task<IActionResult> GetByTagId(string tagId)
        {
            var user = await _userFacade.GetByTagId(tagId);

            return Ok(user);
        }

        /// <summary>
        /// Endpoint for user registration.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {

            var result = await _userFacade.Register(command);
            return Ok(result);
        }


        /// <summary>
        /// User login endpoint.
        /// </summary>
        /// <param name="COmmand.TaggId"></param>
        /// <returns>Token</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            if (string.IsNullOrEmpty(command.TagId))
                return BadRequest("Field cannot be null");

            var token = await _userFacade.Login(command);

            return Ok(token);
        }

    }
}
