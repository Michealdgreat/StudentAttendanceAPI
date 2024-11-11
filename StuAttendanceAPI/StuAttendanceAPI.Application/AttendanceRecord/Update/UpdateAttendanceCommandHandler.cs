using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Update
{
    public class UpdateAttendanceCommandHandler : IBaseCommandHandler<UpdateAttendanceCommand>
    {
        public Task<OperationResult> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
