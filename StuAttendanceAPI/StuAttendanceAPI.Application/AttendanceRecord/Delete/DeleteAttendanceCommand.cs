using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Delete
{
    public class DeleteAttendanceCommand : IBaseCommand
    {
        public Guid AttendanceId { get; private set; }

    }
}
