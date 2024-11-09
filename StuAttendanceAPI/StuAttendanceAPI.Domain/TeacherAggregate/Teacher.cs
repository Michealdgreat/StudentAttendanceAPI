using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuAttendanceAPI.Domain.TeacherAggregate
{
    public class Teacher
    {

        public Guid TeacherId { get; private set; }
        public Guid UserId { get; private set; }
        public string Department { get; private set; }


        private Teacher(Guid teacherId, Guid userId, string department)
        {
            TeacherId = teacherId;
            UserId = userId;
            Department = department;
        }

        /// <summary>
        /// Teacher
        /// </summary>
        public static class TeacherFactory
        {
            public static Teacher CreateNew(Guid userId, string department)
            {
                return new Teacher(Guid.NewGuid(), userId, department);
            }

            public static Teacher UpdateExisting(Guid teacherId, Guid userId, string department)
            {
                return new Teacher(teacherId, userId, department);
            }

            public static Teacher DeleteTeacher(Teacher teacher)
            {

                return null!;
            }
        }
    }
}
