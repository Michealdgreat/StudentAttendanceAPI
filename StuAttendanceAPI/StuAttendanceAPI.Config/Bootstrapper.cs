using Application.User.DeleteUser;
using Application.User.Register;
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
using System.Reflection;

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

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly);
                config.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
                config.RegisterServicesFromAssembly(typeof(GetUserByIdQueryHandler).Assembly);
                config.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly);

            });

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserFacade, UserFacade>();
            services.AddTransient<ICourseFacade, CourseFacade>();
            services.AddTransient<IAttendanceFacade, AttendanceFacade>();
            services.AddTransient<ISessionFacade, SessionFacade>();

        }
    }
}
