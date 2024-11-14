using Common.Application;
using StuAttendanceAPI.Application.AttendanceRecord.Create;
using StuAttendanceAPI.Application.AttendanceRecord.Delete;
using StuAttendanceAPI.Application.AttendanceRecord.Update;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.PresentationFacade.Attendance
{
    public interface IAttendanceFacade
    {
        Task<OperationResult> CreateAttendanceRecord(CreateAttendanceCommand command);
        Task<OperationResult> DeleteAttendanceRecord(DeleteAttendanceCommand command);
        Task<List<AttendanceRecordDto>?> GetAttendanceBySessionAndStudentId(Guid SessionId, Guid StudentId);
        Task<List<AttendanceRecordDto>?> GetAttendanceBySessionId(Guid SessionId);
        Task<OperationResult> UpdateAttendanceRecord(UpdateAttendanceCommand command);
    }
}
