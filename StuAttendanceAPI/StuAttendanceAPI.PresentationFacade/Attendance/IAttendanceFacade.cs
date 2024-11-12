using Common.Application;
using StuAttendanceAPI.Application.AttendanceRecord.Create;
using StuAttendanceAPI.Application.AttendanceRecord.Delete;
using StuAttendanceAPI.Application.AttendanceRecord.Update;
using System;
using System.Linq;

namespace StuAttendanceAPI.PresentationFacade.Attendance
{
    public interface IAttendanceFacade
    {
        Task<OperationResult> CreateAttendanceRecord(CreateAttendanceCommand command);
        Task<OperationResult> DeleteAttendanceRecord(DeleteAttendanceCommand command);
        Task<OperationResult> UpdateAttendanceRecord(UpdateAttendanceCommand command);
    }
}
