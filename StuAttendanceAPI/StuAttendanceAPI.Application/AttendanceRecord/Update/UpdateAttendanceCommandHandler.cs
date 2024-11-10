using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
