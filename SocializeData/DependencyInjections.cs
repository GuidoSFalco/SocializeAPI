using SocializeData.DbContexts;
using SocializeData.Interfaces;
using SocializeData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocializeData
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddEventEaseDataLayerDependencyInjections(this IServiceCollection service, IConfiguration configuration)
        {
            // Add MySql Connection.
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString: configuration.GetConnectionString("SqlServerDataConnection")), ServiceLifetime.Scoped);

            // Add Repositories.
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            service.AddScoped<IEventRepository, EventRepository>();
            service.AddScoped<IDbContextTransactionRepository, DbContextTransactionRepository>();
            

            return service;
        }
    }
}