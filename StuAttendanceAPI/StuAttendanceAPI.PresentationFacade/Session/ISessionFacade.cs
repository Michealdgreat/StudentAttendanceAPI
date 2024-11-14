using Common.Application;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
using StuAttendanceAPI.Domain.SessionAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.PresentationFacade.Session
{
    public interface ISessionFacade
    {
        Task<OperationResult> CreateSession(CreateSessionCommand command);
        Task<OperationResult> DeleteSession(DeleteSessionCommand command);
        Task<List<SessionDto>?> GetAllSessions();
        Task<List<SessionDto>?> GetSessionByCourseId(Guid CourseId);
        Task<SessionDto?> GetSessionById(Guid SessionId);
        Task<OperationResult> UpdateSession(UpdateSessionCommand command);
    }
}
