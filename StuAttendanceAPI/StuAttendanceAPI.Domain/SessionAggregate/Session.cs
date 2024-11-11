using System;
using System.Linq;

namespace StuAttendanceAPI.Domain.SessionAggregate
{
    public class Session
    {
        public Guid SessionId { get; private set; }
        public Guid CourseId { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan StartAt { get; private set; }
        public TimeSpan EndAt { get; private set; }
        public string Name { get; private set; }
        public TimeSpan TotalDuration { get; private set; }


        private Session(Guid sessionId, Guid courseId, DateTime date, TimeSpan startAt, TimeSpan endAt, string name)
        {
            SessionId = sessionId;
            CourseId = courseId;
            Date = date;
            StartAt = startAt;
            EndAt = endAt;
            Name = name;
            TotalDuration = endAt - startAt;
        }


        public static class SessionFactory
        {
            public static Session CreateNew(Guid courseId, DateTime date, TimeSpan startAt, TimeSpan endAt, string name)
            {
                return new Session(Guid.NewGuid(), courseId, date, startAt, endAt, name);
            }

            public static Session UpdateExisting(Guid sessionId, Guid courseId, DateTime date, TimeSpan startAt, TimeSpan endAt, string name)
            {
                return new Session(sessionId, courseId, date, startAt, endAt, name);
            }

            public static Session DeleteSession(Session session)
            {

                return null!;
            }
        }
    }
}
