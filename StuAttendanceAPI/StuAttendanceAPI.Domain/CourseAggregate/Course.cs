using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Domain.CourseAggregate
{
    public class Course
    {
        public Guid CourseId { get; private set; }
        public string CourseName { get; private set; }
        public Guid TeacherId { get; private set; }
        public DateTime CreatedAt { get; private set; }


        private Course(Guid courseId, string courseName, Guid teacherId, DateTime createdAt)
        {
            CourseId = courseId;
            CourseName = courseName;
            TeacherId = teacherId;
            CreatedAt = createdAt;
        }


        public static class CourseFactory
        {
            public static Course CreateNew(string courseName, Guid teacherId)
            {
                return new Course(Guid.NewGuid(), courseName, teacherId, DateTime.Now);
            }

            public static Course UpdateExisting(Guid courseId, string courseName, Guid teacherId, DateTime createdAt)
            {
                return new Course(courseId, courseName, teacherId, createdAt);
            }

            public static Course DeleteCourse(Course course)
            {

                return null!;
            }
        }
    }
}
