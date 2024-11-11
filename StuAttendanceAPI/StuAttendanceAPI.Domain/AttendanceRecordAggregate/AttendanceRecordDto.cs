using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Domain.AttendanceRecordAggregate
{
    public class AttendanceRecordDto
    {
        public Guid AttendanceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime SignInAt { get; set; }
        public DateTime SignOutAt { get; set; }
    }
}
