﻿namespace StuAttendanceAPI.Domain.ContextHelper
{
    public class StuAttSqlFactory
    {
        private StuAttSqlFactory() { }

        private static class Queries
        {
            internal const string GetUserById = "SELECT * FROM get_user_by_id(@p_uid)";
            internal const string GetUserByEmail = "SELECT * FROM get_user_by_email(@p_email)";
            internal const string GetCourseById = "SELECT * FROM public.get_course_by_id(@p_course_id)";
            internal const string GetCourseByName = "SELECT * FROM get_course_by_name(@p_course_name)";
            internal const string GetCoursesByTeacherName = "SELECT * FROM get_courses_by_teacher_name(@p_teacher_name)";
            internal const string GetStudentById = "SELECT * FROM get_student_by_id(@p_sid)";
            internal const string GetAttendanceForSession = "SELECT * FROM get_attendance_for_session(@p_session_id)";
            internal const string GetSessionsForCourse = "SELECT * FROM get_sessions_for_course(@input_course_id)";
            internal const string GetStudentsForCourse = "SELECT * FROM get_students_for_course(@p_course_id)";
            internal const string GetTeacherCoursesAndSessions = "SELECT * FROM get_teacher_courses_and_sessions(@p_teacher_id)";
            internal const string GetUserByRole = "SELECT * FROM get_user_by_role(@p_user_role)";
            internal const string GetUserByPassword = "SELECT * FROM public.get_user_by_password(@p_password)";
            internal const string GetAttendanceBySessionAndStudent = "SELECT * FROM public.get_attendance_for_session_and_student(@p_session_id, @p_student_id)";
            internal const string GetSessionById = "SELECT * FROM public.get_session_by_id(@p_session_id)";
            internal const string GetSessionDetailsById = "SELECT * FROM public.get_session_details_by_id(@p_session_id)";
            internal const string GetCoursesByTeacherId = "SELECT * FROM public.get_courses_by_teacher_id(@p_teacher_id)";
            internal const string GetAllSessions = "SELECT * FROM public.get_all_sessions()";
        }

        public static (string Query, object Parameters) GetUserByIdQuery(Guid uid)
        {
            var parameters = new { p_uid = uid };
            return (Queries.GetUserById, parameters);
        }

        public static (string Query, object Parameters) GetUserByEmailQuery(string email)
        {
            var parameters = new { p_email = email };
            return (Queries.GetUserByEmail, parameters);
        }

        public static (string Query, object Parameters) GetCourseByIdQuery(Guid courseId)
        {
            var parameters = new { p_course_id = courseId };
            return (Queries.GetCourseById, parameters);
        }

        public static (string Query, object Parameters) GetCourseByNameQuery(string courseName)
        {
            var parameters = new { p_course_name = courseName };
            return (Queries.GetCourseByName, parameters);
        }

        public static (string Query, object Parameters) GetCoursesByTeacherNameQuery(string teacherName)
        {
            var parameters = new { p_teacher_name = teacherName };
            return (Queries.GetCoursesByTeacherName, parameters);
        }

        public static (string Query, object Parameters) GetStudentByIdQuery(Guid sid)
        {
            var parameters = new { p_sid = sid };
            return (Queries.GetStudentById, parameters);
        }

        public static (string Query, object Parameters) GetAttendanceForSessionQuery(Guid sessionId)
        {
            var parameters = new { p_session_id = sessionId };
            return (Queries.GetAttendanceForSession, parameters);
        }

        public static (string Query, object Parameters) GetSessionsForCourseQuery(Guid courseId)
        {
            var parameters = new { input_course_id = courseId };
            return (Queries.GetSessionsForCourse, parameters);
        }

        public static (string Query, object Parameters) GetStudentsForCourseQuery(Guid courseId)
        {
            var parameters = new { p_course_id = courseId };
            return (Queries.GetStudentsForCourse, parameters);
        }

        public static (string Query, object Parameters) GetTeacherCoursesAndSessionsQuery(Guid teacherId)
        {
            var parameters = new { p_teacher_id = teacherId };
            return (Queries.GetTeacherCoursesAndSessions, parameters);
        }

        public static (string Query, object Parameters) GetUserByRoleQuery(string userRole)
        {
            var parameters = new { p_user_role = userRole };
            return (Queries.GetUserByRole, parameters);
        }

        public static (string Query, object Parameters) GetUserByPasswordQuery(string password)
        {
            var parameters = new { p_password = password };
            return (Queries.GetUserByPassword, parameters);
        }

        public static (string Query, object Parameters) GetAttendanceBySessionAndStudentQuery(Guid sessionId, Guid studentId)
        {
            var parameters = new { p_session_id = sessionId, p_student_id = studentId };
            return (Queries.GetAttendanceBySessionAndStudent, parameters);
        }
        public static (string Query, object Parameters) GetSessionByIdQuery(Guid sessionId)
        {
            var parameters = new { p_session_id = sessionId };
            return (Queries.GetSessionById, parameters);
        }
        public static (string Query, object Parameters) GetSessionDetailsByIdQuery(Guid sessionId)
        {
            var parameters = new { p_session_id = sessionId };
            return (Queries.GetSessionById, parameters);
        }
        public static (string Query, object Parameters) GetCoursesByTeacherIdQuery(Guid teacherId)
        {
            var parameters = new { p_teacher_id = teacherId };
            return (Queries.GetCoursesByTeacherId, parameters);
        }

        public static string GetAllSessionsFunctionQuery()
        {
            return Queries.GetAllSessions;
        }
    }
}