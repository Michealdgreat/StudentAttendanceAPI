using Common.Query;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Attendance.GetBySessionId
{
    public record GetAttendanceBySessionIdQuery(Guid SessionId) : IQuery<List<AttendanceRecordDto>?>;
}
