using Microsoft.Extensions.DependencyInjection;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Breed;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Categories;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Clients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Common;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Consults;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Diagnostico;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Exams;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Patients;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Products;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.Specie;
using SIG_VETERINARIA.Abstractions.Interfaces.IServices.User;
using SIG_VETERINARIA.Services.Common;
using SIG_VETERINARIA.Services.Services.Breed;
using SIG_VETERINARIA.Services.Services.Categories;
using SIG_VETERINARIA.Services.Services.Clients;
using SIG_VETERINARIA.Services.Services.Consults;
using SIG_VETERINARIA.Services.Services.Diagnostico;
using SIG_VETERINARIA.Services.Services.Exams;
using SIG_VETERINARIA.Services.Services.Patients;
using SIG_VETERINARIA.Services.Services.Products;
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
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IConsultService, ConsultService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IDiagnosticoService, DiagnosticoService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
