using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.Session.Create
{
    public class CreateSessionCommandHandler : IBaseCommandHandler<CreateSessionCommand>
    {
        public Task<OperationResult> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
