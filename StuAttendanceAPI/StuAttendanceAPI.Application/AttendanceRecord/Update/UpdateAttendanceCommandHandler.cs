using Common.Application;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using System;
using System.Linq;
using static StuAttendanceAPI.Domain.AttendanceRecordAggregate.AttendanceRecord;

namespace StuAttendanceAPI.Application.AttendanceRecord.Update
{

    public class UpdateAttendanceCommandHandler(IAttendanceRecordRepository attendanceRepository) : IBaseCommandHandler<UpdateAttendanceCommand>
    {
        private readonly IAttendanceRecordRepository _attendanceRepository = attendanceRepository;

        public async Task<OperationResult> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var attendance = AttendanceFactory.UpdateExisting(request.AttendanceId, request.SessionId, request.StudentId, request.SignInAt, request.SignOutAt);

                await _attendanceRepository.SaveData<dynamic>("update_attendance_record", new
                {
                    attendance_id = attendance.AttendanceId,
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
