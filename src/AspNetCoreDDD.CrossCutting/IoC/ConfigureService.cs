using AspNetCoreDDD.Domain.Interfaces.Services.User;
using AspNetCoreDDD.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDDD.CrossCutting.IoC
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService (IServiceCollection services)
        {
            // Transient, create a new instance by use
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}