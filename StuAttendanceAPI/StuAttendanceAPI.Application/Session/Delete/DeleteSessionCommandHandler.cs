using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.Session.Delete
{
    public class DeleteSessionCommandHandler : IBaseCommandHandler<DeleteSessionCommand>
    {
        public Task<OperationResult> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
