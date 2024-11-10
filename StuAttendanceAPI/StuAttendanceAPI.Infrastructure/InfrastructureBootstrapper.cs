using Application.User.Services;
using Microsoft.Extensions.DependencyInjection;
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

        }
    }
}