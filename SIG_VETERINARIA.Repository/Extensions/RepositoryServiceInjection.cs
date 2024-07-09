using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.User;
using SIG_VETERINARIA.Repository.Repository.Breeds;
using SIG_VETERINARIA.Repository.Repository.Clients;
using SIG_VETERINARIA.Repository.Repository.Species;
using SIG_VETERINARIA.Repository.Repository.User;

namespace SIG_VETERINARIA.Repository.Extensions
{
    public static class RepositoryServiceInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISpeciesRepository, SpecieRepository>();
            services.AddScoped<IBreedRepository, BreedRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
