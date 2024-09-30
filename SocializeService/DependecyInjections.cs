using SocializeData;
using SocializeService.Interfaces;
using SocializeService.Mappings.Configuration;
using SocializeService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocializeService
{
    public static class DependecyInjections
    {
        public static IServiceCollection AddEventEaseDataLayerDependencyInjectionsInternal(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddEventEaseDataLayerDependencyInjections(configuration);
            // Add automapper
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            /* Automapper Mappings */
            service.AddSingleton(ProfilesConfiguration.MapProfiles());

            // Add services.
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IEventService, EventService>();

            return service;
        }
    }
}
