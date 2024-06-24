using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication;
using SIG_VETERINARIA.Application.Application.User;

namespace SIG_VETERINARIA.Application.Extensions
{
    public static class ApplicationServiceInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            return services;
        }
    }
}
