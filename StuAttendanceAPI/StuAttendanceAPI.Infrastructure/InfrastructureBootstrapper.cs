using Application.User.Services;
using Microsoft.Extensions.DependencyInjection;
using StuAttendanceAPI.Domain.AttendanceRecordAggregate;
using StuAttendanceAPI.Domain.CourseAggregate;
using StuAttendanceAPI.Domain.SessionAggregate;
using StuAttendanceAPI.Domain.StudentAggregate;
using StuAttendanceAPI.Domain.TeacherAggregate;
using StuAttendanceAPI.Domain.UserAggregate;
using StuAttendanceAPI.Infrastructure.Repositories;

namespace StuAttendanceAPI.Infrastructure
{
    /// <summary>
    /// Infrastructure Dependencies injection registration.
    /// </summary>
    public static class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IAttendanceRecordRepository, AttendanceRecordRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();


        }
    }
}