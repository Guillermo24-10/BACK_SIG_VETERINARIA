using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Categories;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Consults;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Diagnostico;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Exams;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Patients;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Products;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Tratamiento;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.User;
using SIG_VETERINARIA.Repository.Repository.Breeds;
using SIG_VETERINARIA.Repository.Repository.Categories;
using SIG_VETERINARIA.Repository.Repository.Clients;
using SIG_VETERINARIA.Repository.Repository.Consults;
using SIG_VETERINARIA.Repository.Repository.Diagnostico;
using SIG_VETERINARIA.Repository.Repository.Exams;
using SIG_VETERINARIA.Repository.Repository.Patients;
using SIG_VETERINARIA.Repository.Repository.Products;
using SIG_VETERINARIA.Repository.Repository.Species;
using SIG_VETERINARIA.Repository.Repository.Tratamientos;
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
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IConsultRepository, ConsultRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITratamientosRepository, TratamientoRepository>();
            services.AddScoped<IProductsTratamientoRepository, ProductsTratamientoRepository>();

            return services;
        }
    }
}
