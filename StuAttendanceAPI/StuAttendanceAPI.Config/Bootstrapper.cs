using Application.User.DeleteUser;
using Application.User.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StuAttendanceAPI.Application.User.Services;
using StuAttendanceAPI.Infrastructure;
using StuAttendanceAPI.PresentationFacade.Attendance;
using StuAttendanceAPI.PresentationFacade.Course;
using StuAttendanceAPI.PresentationFacade.Session;
using StuAttendanceAPI.PresentationFacade.User;
using StuAttendanceAPI.Query.User.GetById;

namespace StuAttendanceAPI.Config
{
    public static class Bootstrapper
    {

        /// <summary>
        /// Dependencies injection for command and handers.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void ConfigBootstrapper(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(typeof(DeleteUserCommand).Assembly);
            services.AddMediatR(typeof(DeleteUserCommandHandler).Assembly);
            services.AddMediatR(typeof(GetUserByIdQuery).Assembly);
            services.AddMediatR(typeof(GetUserByIdQueryHandler).Assembly);

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserFacade, UserFacade>();
            services.AddTransient<ICourseFacade, CourseFacade>();
            services.AddTransient<IAttendanceFacade, AttendanceFacade>();
            services.AddTransient<ISessionFacade, SessionFacade>();

        }
    }
}
