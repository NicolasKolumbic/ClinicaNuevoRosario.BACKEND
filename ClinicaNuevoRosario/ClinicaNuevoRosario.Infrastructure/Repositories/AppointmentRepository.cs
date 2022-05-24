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
            var appointments = this._context.Appointments.Include(x => x.HealthInsurance).Include(x => x.Doctor);
            return appointments.AsQueryable();
        }
    }
}
