using ClinicaNuevoRosario.Application.Contracts.External;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using ClinicaNuevoRosario.Infrastructure.Email;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using ClinicaNuevoRosario.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaNuevoRosario.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CNRDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSetting"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IMedicalSpecialitiesRepository, MedicalSpecialitiesRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IHealthInsurancesRepository, HealthInsurancesRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();

            return services;
        }
    }
}
