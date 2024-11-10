using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Application.AttendanceRecord.Update
{
    public class UpdateAttendanceCommand : IBaseCommand
    {
        public Guid AttendanceId { get; private set; }
        public Guid SessionId { get; private set; }
        public Guid StudentId { get; private set; }
        public DateTime SignInAt { get; private set; }
        public DateTime SignOutAt { get; private set; }
    }
}
