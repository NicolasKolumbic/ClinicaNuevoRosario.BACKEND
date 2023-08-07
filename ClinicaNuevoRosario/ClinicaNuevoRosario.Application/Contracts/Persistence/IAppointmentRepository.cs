using ClinicaNuevoRosario.Domain;
using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IAppointmentRepository: IAsyncRepository<Appointment>
    {
        public Task<IQueryable<Appointment>> GetAllApointments();
        public Task<IQueryable<Appointment>> GetByDoctorId(int doctorId);
        public Task<IQueryable<Appointment>> GetAppointmentByHealthInsuranceId(int healthInsuranceId);
        public Task<IQueryable<Appointment>> GetByEmail(string email);
        public Task<IQueryable<Appointment>> Filter(Expression<Func<Appointment, bool>> expression);
        public Task<Appointment> GetAppointmentById(int appointmentId);

    }
}
