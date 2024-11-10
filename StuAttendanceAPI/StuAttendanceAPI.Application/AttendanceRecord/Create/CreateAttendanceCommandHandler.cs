using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
