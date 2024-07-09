using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.User;
using SIG_VETERINARIA.Services.Services.Breed;
using SIG_VETERINARIA.Services.Services.Clients;
using SIG_VETERINARIA.Services.Services.Specie;
using SIG_VETERINARIA.Services.Services.User;

namespace SIG_VETERINARIA.Services.Extensions
{
    public static class ServicesServiceInjection
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISpecieService, SpecieService>();
            services.AddScoped<IBreedService, BreedService>();
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
