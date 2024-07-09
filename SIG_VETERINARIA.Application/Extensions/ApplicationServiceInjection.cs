using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.User;
using SIG_VETERINARIA.Application.Application.Breed;
using SIG_VETERINARIA.Application.Application.Clients;
using SIG_VETERINARIA.Application.Application.Specie;
using SIG_VETERINARIA.Application.Application.User;

namespace SIG_VETERINARIA.Application.Extensions
{
    public static class ApplicationServiceInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ISpecieApplication, SpecieApplication>();
            services.AddScoped<IBreedApplication, BreedApplication>();
            services.AddScoped<IClientApplication, ClientApplication>();

            return services;
        }
    }
}
