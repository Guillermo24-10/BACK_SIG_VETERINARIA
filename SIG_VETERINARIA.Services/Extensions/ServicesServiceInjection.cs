using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices;
using SIG_VETERINARIA.Services.Services.User;

namespace SIG_VETERINARIA.Services.Extensions
{
    public static class ServicesServiceInjection
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
