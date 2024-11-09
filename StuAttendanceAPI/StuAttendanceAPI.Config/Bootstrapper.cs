using Application.User.DeleteUser;
using Application.User.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StuAttendanceAPI.Application.User.Services;
using StuAttendanceAPI.Infrastructure;
using StuAttendanceAPI.PresentationFacade.User;

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

            services.AddTransient<ITokenService, TokenService>();

            services.AddTransient<IUserFacade, UserFacade>();

            services.AddTransient<IUserFacade, UserFacade>();
        }
    }
}
