using Common.Application;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using System;
using System.Linq;
using static StuAttendanceAPI.Domain.AttendanceRecordAggregate.AttendanceRecord;

namespace StuAttendanceAPI.Application.AttendanceRecord.Create
{
    public class CreateAttendanceCommandHandler(IAttendanceRecordRepository attendanceRepository) : IBaseCommandHandler<CreateAttendanceCommand>
    {
        private readonly IAttendanceRecordRepository _attendanceRepository = attendanceRepository;

        public async Task<OperationResult> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var attendance = AttendanceFactory.CreateNew(request.SessionId, request.StudentId, request.SignInAt, request.SignOutAt);

                await _attendanceRepository.SaveData<dynamic>("insert_attendance_record", new
                {
                    attendance_id = attendance.AttendanceId,
                    session_id = attendance.SessionId,
                    student_id = attendance.StudentId,
                    sign_in_at = attendance.SignInAt,
                    sign_out_at = attendance.SignOutAt

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
