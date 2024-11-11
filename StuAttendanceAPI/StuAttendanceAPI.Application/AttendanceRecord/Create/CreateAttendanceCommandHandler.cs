using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Create
{
    internal class CreateAttendanceCommandHandler : IBaseCommandHandler<CreateAttendanceCommand>
    {
        public Task<OperationResult> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
