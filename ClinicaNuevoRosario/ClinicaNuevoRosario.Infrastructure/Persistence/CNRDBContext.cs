using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ClinicaNuevoRosario.Infrastructure.Persistence
{
    public class CNRDBContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<HealthInsurance> HealthInsurances { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<AppointmentState> AppointmentStates { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public CNRDBContext(DbContextOptions<CNRDBContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.UpdatedBy = "System";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.CreatedBy = "System";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync();
        }



    }
}