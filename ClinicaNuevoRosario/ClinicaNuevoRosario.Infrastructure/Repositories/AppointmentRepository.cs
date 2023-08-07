using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(CNRDBContext context) : base(context)
        {
        }

        public async Task<IQueryable<Appointment>> GetAllApointments()
        {
            var appointments = this._context.Appointments
                .Include(x => x.Doctor)
                .ThenInclude(x => x.MedicalSpecialties)
                .Include(x => x.ServiceType)
                .Include(x => x.Patient)
                .ThenInclude(x => x.Plan)
                .ThenInclude(x => x.HealthInsurance);

            return appointments.AsQueryable();
        }

        public async Task<IQueryable<Appointment>> GetByDoctorId(int doctorId)
        {
            var appointments = this._context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.AppointmentState)
                .Include(x => x.ServiceType)
                .Include(x => x.Doctor)
                .Where(x => x.DoctorId == doctorId);

            return appointments.AsQueryable();
        }

        public async Task<IQueryable<Appointment>> GetByEmail(string email)
        {
            var appointments = this._context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.AppointmentState)
                .Include(x => x.ServiceType)
                .Include(x => x.Doctor)
                .Where(x => x.Doctor.Email == email);

            return appointments.AsQueryable();
        }

        public async Task<IQueryable<Appointment>> GetAppointmentByHealthInsuranceId(int healthInsuranceId)
        {
            var appointments = this._context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.AppointmentState)
                .Include(x => x.ServiceType)
                .Where(x => x.Patient.Plan.HealthInsurance.Id == healthInsuranceId);

            return appointments.AsQueryable();
        }

        public async Task<Appointment> GetAppointmentById(int appointmentId)
        {
            var appointment = this._context.Appointments
                .Include (x => x.Doctor)
                .Include(x => x.Patient)
                .ThenInclude(x => x.Plan)
                .ThenInclude(x => x.HealthInsurance)
                .OrderByDescending(x => x.CreateDate)
                .Include(x => x.AppointmentState)
                .Include(x => x.ServiceType)               
                .Where(x => x.Id == appointmentId)
                .FirstOrDefault();

            return appointment;
        }

        public async Task<IQueryable<Appointment>> Filter(Expression<Func<Appointment, bool>> expression)
        {
            return this._context.Appointments
                .Include(x => x.Doctor)
                .ThenInclude(x => x.MedicalSpecialties)
                .Include(x => x.Patient)
                .ThenInclude(x => x.Plan)
                .ThenInclude(x => x.HealthInsurance)
                .OrderByDescending(x => x.CreateDate)
                .Include(x => x.AppointmentState)
                .Include(x => x.ServiceType)
                .Where(expression);
        }
    }
}
