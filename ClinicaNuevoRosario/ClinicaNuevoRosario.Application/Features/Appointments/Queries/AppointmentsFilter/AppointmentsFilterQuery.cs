using ClinicaNuevoRosario.Application.Helpers;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.AppointmentsFilter
{
    public class AppointmentsFilterQuery : IRequest<List<AppointmentDto>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? HealthInsuranceId { get; set; }
        public int? MedicalSpecialtyId { get; set; }
        public int? DoctorId { get; set; }
        public ServiceTypes? ServiceType { get; set; }
        public AppointmentStates? AppointmentState { get; set; }
        public DateTime? Month { get; set; }

    }
}
