using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
                .Include(x => x.Patient);

            return appointments.AsQueryable();
        }

        public async Task<IQueryable<Appointment>> GetByDoctorId(int doctorId)
        {
            var appointments = this._context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Where(x => x.DoctorId == doctorId);

            return appointments.AsQueryable();
        }
    }
}
