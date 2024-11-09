using Application.User.DeleteUser;
using Application.User.Register;
using Application.User.Services;
using Application.User.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserService _userService;
        public UserController(IUserFacade userFacade, IUserService userService)
        {
            _userFacade = userFacade;
            _userService = userService;
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
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email))
                return BadRequest("Email field cannot be null");

            if (string.IsNullOrEmpty(Password))
                return BadRequest("Password cannot be null");

            var token = await _userService.GenerateAToken(Email, Password);
            return Ok(token);
        }

    }
}
