using Common.Application;
using MediatR;
using StuAttendanceAPI.Application.AttendanceRecord.Create;
using StuAttendanceAPI.Application.AttendanceRecord.Delete;
using StuAttendanceAPI.Application.AttendanceRecord.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.PresentationFacade.Attendance
{
    public class AttendanceFacade(IMediator mediator)
: IAttendanceFacade
    {
        private readonly IMediator _mediator = mediator;

        public async Task<OperationResult> CreateAttendanceRecord(CreateAttendanceCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<OperationResult> UpdateAttendanceRecord(UpdateAttendanceCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<OperationResult> DeleteAttendanceRecord(DeleteAttendanceCommand command)
        {
            return await _mediator.Send(command);

        }
    }
}
