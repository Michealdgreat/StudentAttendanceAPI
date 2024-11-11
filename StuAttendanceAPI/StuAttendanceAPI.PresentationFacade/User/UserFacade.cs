using Application.User.DeleteUser;
using Application.User.Register;
using Common.Application;
using MediatR;
using StuAttendanceAPI.Application.User.UserLogin;
using StuAttendanceAPI.Query.User.DTO;
using StuAttendanceAPI.Query.User.GetById;
using StuAttendanceAPI.Query.User.GetList;

namespace StuAttendanceAPI.PresentationFacade.User
{
    /// <summary>
    /// User facade implementation.
    /// </summary>
    public class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;
        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Register(RegisterUserCommand request)
        {
            return await _mediator.Send(request);
        }

        public async Task<Object> Login(UserLoginCommand request)
        {
            return await _mediator.Send(request);
        }


        public async Task<UserDTO> GetById(Guid UserId)
        {
            return await _mediator.Send(new GetUserByIdQuery(UserId));
        }

        public async Task<List<UserDTO>> GetList()
        {
            return await _mediator.Send(new GetUserListQuery());
        }

        public async Task<OperationResult> DeleteUser(DeleteUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}