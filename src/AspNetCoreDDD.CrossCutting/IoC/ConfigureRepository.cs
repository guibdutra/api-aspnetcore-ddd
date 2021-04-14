using AspNetCoreDDD.Infrastructure.Context;
using AspNetCoreDDD.Domain.Interfaces;
using AspNetCoreDDD.Infrastructure.Repository;
using AspNetCoreDDD.Infrastructure.RepositoryImplementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreDDD.Domain.Repository;

namespace AspNetCoreDDD.CrossCutting.IoC
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserImplementation>();
            
            services.AddDbContext<MyContext> (
                options => options.UseMySql(configuration.GetConnectionString("Default"))
            );
        }
    }
}