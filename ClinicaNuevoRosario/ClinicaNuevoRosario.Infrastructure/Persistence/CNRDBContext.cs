﻿using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ClinicaNuevoRosario.Infrastructure.Persistence
{
    public class CNRDBContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicRole> ClinicRoles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorMedicalSpecialty> DoctorMedicalSpecialties { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HealthInsurance> HealthInsurances { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public CNRDBContext(DbContextOptions<CNRDBContext> options): base(options)
        {
                
        }

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