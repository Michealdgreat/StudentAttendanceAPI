using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Domain.StudentAggregate
{
    public class Student
    {
        public Guid StudentId { get; private set; }
        public Guid UserId { get; private set; }
        public string StudentGroup { get; private set; }

        private Student(Guid studentId, Guid userId, string studentGroup)
        {
            StudentId = studentId;
            UserId = userId;
            StudentGroup = studentGroup;
        }


        public static class StudentFactory
        {
            public static Student CreateNew(Guid userId, string studentGroup)
            {
                return new Student(Guid.NewGuid(), userId, studentGroup);
            }

            public static Student UpdateExisting(Guid studentId, Guid userId, string studentGroup)
            {
                return new Student(studentId, userId, studentGroup);
            }

            public static Student DeleteStudent(Student student)
            {

                return null!;
            }
        }
    }
}
