using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
