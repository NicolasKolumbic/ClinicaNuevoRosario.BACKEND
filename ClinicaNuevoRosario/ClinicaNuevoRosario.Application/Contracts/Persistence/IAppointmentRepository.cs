using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IAppointmentRepository: IAsyncRepository<Appointment>
    {
        public Task<IQueryable<Appointment>> GetAllApointments();
        public Task<IQueryable<Appointment>> GetByDoctorId(int doctorId);
        public Task<IQueryable<Appointment>> GetAppointmentByHealthInsuranceId(int healthInsuranceId);
        public Task<IQueryable<Appointment>> GetByEmail(string email);
        public Task<Appointment> GetAppointmentById(int appointmentId);
    }
}
