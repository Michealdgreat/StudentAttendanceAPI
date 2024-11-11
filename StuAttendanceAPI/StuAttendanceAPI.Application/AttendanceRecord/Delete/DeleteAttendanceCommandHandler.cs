using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Delete
{
    public class DeleteAttendanceCommandHandler : IBaseCommandHandler<DeleteAttendanceCommand>
    {
        public Task<OperationResult> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
