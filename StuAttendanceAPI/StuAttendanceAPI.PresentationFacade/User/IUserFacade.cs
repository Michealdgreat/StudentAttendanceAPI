﻿using Application.User.DeleteUser;
using Application.User.Register;
using Common.Application;
using StuAttendanceAPI.Application.User.UserLogin;
using StuAttendanceAPI.Query.User.DTO;

namespace StuAttendanceAPI.PresentationFacade.User
{
    /// <summary>
    /// User facade interface
    /// </summary>
    public interface IUserFacade
    {
        Task<OperationResult> Register(RegisterUserCommand request);
        Task<object> Login(UserLoginCommand request);
        Task<OperationResult> DeleteUser(DeleteUserCommand command);
        Task<UserDTO> GetById(Guid UserId);
        Task<List<UserDTO>> GetList();
    }
}