using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Domain.AttendanceRecordAggregate
{
    public class AttendanceRecord
    {
        public Guid AttendanceId { get; private set; }
        public Guid SessionId { get; private set; }
        public Guid StudentId { get; private set; }
        public DateTime SignInAt { get; private set; }
        public DateTime SignOutAt { get; private set; }

        private AttendanceRecord(Guid attendanceId, Guid sessionId, Guid studentId, DateTime signInAt, DateTime signOutAt)
        {
            AttendanceId = attendanceId;
            SessionId = sessionId;
            StudentId = studentId;
            SignInAt = signInAt;
            SignOutAt = signOutAt;
        }


        public static class AttendanceFactory
        {
            public static AttendanceRecord CreateNew(Guid sessionId, Guid studentId, DateTime signInAt, DateTime signOutAt)
            {
                return new AttendanceRecord(Guid.NewGuid(), sessionId, studentId, signInAt, signOutAt);
            }

            public static AttendanceRecord UpdateExisting(Guid attendanceId, Guid sessionId, Guid studentId, DateTime signInAt, DateTime signOutAt)
            {
                return new AttendanceRecord(attendanceId, sessionId, studentId, signInAt, signOutAt);
            }

            public static AttendanceRecord DeleteAttendance(AttendanceRecord attendanceRecord)
            {

                return null!;
            }
        }
    }
}
