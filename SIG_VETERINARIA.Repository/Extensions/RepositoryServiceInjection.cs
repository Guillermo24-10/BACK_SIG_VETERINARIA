using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository;
using SIG_VETERINARIA.Repository.Repository.User;

namespace SIG_VETERINARIA.Repository.Extensions
{
    public static class RepositoryServiceInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
