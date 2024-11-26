using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Categories;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Consults;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Diagnostico;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Exams;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Patients;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Products;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.Tratamiento;
using SIG_VETERINARIA.Abstractions.Interfaces.IApplication.User;
using SIG_VETERINARIA.Abstractions.Interfaces.IRepository.Products;
using SIG_VETERINARIA.Application.Application.Breed;
using SIG_VETERINARIA.Application.Application.Categories;
using SIG_VETERINARIA.Application.Application.Clients;
using SIG_VETERINARIA.Application.Application.Consults;
using SIG_VETERINARIA.Application.Application.Diagnostico;
using SIG_VETERINARIA.Application.Application.Exams;
using SIG_VETERINARIA.Application.Application.Patients;
using SIG_VETERINARIA.Application.Application.Products;
using SIG_VETERINARIA.Application.Application.Specie;
using SIG_VETERINARIA.Application.Application.Tratamientos;
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
            services.AddScoped<IPatientApplication, PatientApplication>();
            services.AddScoped<IConsultApplication, ConsultApplication>();
            services.AddScoped<IExamApplication, ExamApplication>();
            services.AddScoped<IDiagnosticoApplication, DiagnosticoApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<ITratamientoApplication, TratamientoApplication>();
            services.AddScoped<IProductsTratamientoApplication, ProductsTratamientoApplication>();

            return services;
        }
    }
}
