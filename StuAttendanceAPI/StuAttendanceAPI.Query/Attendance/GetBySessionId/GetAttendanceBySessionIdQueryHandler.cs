using Common.Query;
using MediatR;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using StuAttendanceAPI.Domain.ContextHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Attendance.GetBySessionId
{
    public class GetAttendanceBySessionIdQueryHandler(IAttendanceRecordRepository attendanceRecordRepository) : IQueryHandler<GetAttendanceBySessionIdQuery, List<AttendanceRecordDto>?>
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository = attendanceRecordRepository;

        public async Task<List<AttendanceRecordDto>?> Handle(GetAttendanceBySessionIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (attendanceQuery, attParameter) = StuAttSqlFactory.GetAttendanceForSessionQuery(request.SessionId);

                return await _attendanceRecordRepository.LoadData<AttendanceRecordDto, dynamic>(attendanceQuery, attParameter);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
