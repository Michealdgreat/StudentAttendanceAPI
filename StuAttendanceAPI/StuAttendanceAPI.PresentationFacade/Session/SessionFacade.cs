using Common.Application;
using MediatR;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
using StuAttendanceAPI.Domain.SessionAggregate;
using StuAttendanceAPI.Query.Session.GetAllSession;
using StuAttendanceAPI.Query.Session.GetSessionById;
using StuAttendanceAPI.Query.Session.GetSessionsByCourseId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.PresentationFacade.Session
{
    public class SessionFacade(IMediator mediator)
: ISessionFacade
    {
        private readonly IMediator _mediator = mediator;

        public async Task<OperationResult> CreateSession(CreateSessionCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteSession(DeleteSessionCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> UpdateSession(UpdateSessionCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SessionDto?> GetSessionById(Guid SessionId)
        {
            return await _mediator.Send(new GetSessionByIdQuery(SessionId));
        }

        public async Task<List<SessionDto>?> GetSessionByCourseId(Guid CourseId)
        {
            return await _mediator.Send(new GetSessionByCourseIdQuery(CourseId));
        }

        public async Task<List<SessionDto>?> GetAllSessions()
        {
            return await _mediator.Send(new GetAllSessionQuery());
        }
    }
}
