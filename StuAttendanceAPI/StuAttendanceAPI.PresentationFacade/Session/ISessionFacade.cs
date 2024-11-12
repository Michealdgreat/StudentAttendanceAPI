using Common.Application;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
using System;
using System.Linq;

namespace StuAttendanceAPI.PresentationFacade.Session
{
    public interface ISessionFacade
    {
        Task<OperationResult> CreateSession(CreateSessionCommand command);
        Task<OperationResult> DeleteSession(DeleteSessionCommand command);
        Task<OperationResult> UpdateSession(UpdateSessionCommand command);
    }
}
