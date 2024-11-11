using Common.Application;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using StuAttendanceAPI.Domain.ContextHelper;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Delete
{
    public class DeleteAttendanceCommandHandler(IAttendanceRecordRepository attendanceRepository) : IBaseCommandHandler<DeleteAttendanceCommand>
    {
        private readonly IAttendanceRecordRepository _attendanceRepository = attendanceRepository;

        public async Task<OperationResult> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var (attQuery, AttPara) = StuAttSqlFactory.GetAttendanceBySessionAndStudentQuery(request.SessionId, request.StudentId);

                var result = await _attendanceRepository.LoadData<AttendanceRecordDto, dynamic>(attQuery, AttPara);

                if (result == null)
                {
                    return OperationResult.NotFound();
                }

                if (request.CommandSender!.UserId != request.StudentId)
                {
                    return OperationResult.Error();
                }

                await _attendanceRepository.DeleteData<dynamic>("delete_attendance_record_by_ids", new
                {
                    p_attendance_id = request.AttendanceId,
                    p_student_id = request.StudentId,
                    p_session_id = request.SessionId,
                });

                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }
    }
}
