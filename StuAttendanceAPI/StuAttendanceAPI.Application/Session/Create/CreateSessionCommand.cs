using Common.Application;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.Session.Create
{
    public class CreateSessionCommand : IBaseCommand
    {
        public Guid SessionId { get; private set; }
        public Guid CourseId { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan StartAt { get; private set; }
        public TimeSpan EndAt { get; private set; }
        public string? Name { get; private set; }
    }
}
