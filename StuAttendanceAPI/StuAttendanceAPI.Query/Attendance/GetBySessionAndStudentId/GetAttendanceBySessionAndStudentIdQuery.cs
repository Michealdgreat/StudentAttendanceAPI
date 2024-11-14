using Common.Query;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Attendance.GetBySessionAndStudentId
{
    public record GetAttendanceBySessionAndStudentIdQuery(Guid SessionId, Guid StudentId) : IQuery<List<AttendanceRecordDto>?>;

}
