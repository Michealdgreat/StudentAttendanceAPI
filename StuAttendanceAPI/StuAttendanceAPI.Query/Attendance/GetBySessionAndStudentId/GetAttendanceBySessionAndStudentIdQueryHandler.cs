using Common.Query;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using StuAttendanceAPI.Domain.ContextHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Query.Attendance.GetBySessionAndStudentId
{
    public class GetAttendanceBySessionAndStudentIdQueryHandler(IAttendanceRecordRepository attendanceRecordRepository) : IQueryHandler<GetAttendanceBySessionAndStudentIdQuery, List<AttendanceRecordDto>?>
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository = attendanceRecordRepository;

        public async Task<List<AttendanceRecordDto>?> Handle(GetAttendanceBySessionAndStudentIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var (attQuery, AttPara) = StuAttSqlFactory.GetAttendanceBySessionAndStudentQuery(request.SessionId, request.StudentId);

                var result = await _attendanceRecordRepository.LoadData<AttendanceRecordDto, dynamic>(attQuery, AttPara);

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
