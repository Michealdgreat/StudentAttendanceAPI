using Common.Application;
using MediatR;
using StuAttendanceAPI.Application.Session.Create;
using StuAttendanceAPI.Application.Session.Delete;
using StuAttendanceAPI.Application.Session.Update;
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

    }
}
