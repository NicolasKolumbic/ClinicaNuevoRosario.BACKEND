using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IAppointmentRepository: IAsyncRepository<Appointment>
    {
        public Task<IQueryable<Appointment>> GetAllApointments();
    }
}
