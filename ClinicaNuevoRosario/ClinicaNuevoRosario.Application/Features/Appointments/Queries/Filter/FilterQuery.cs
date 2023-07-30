using ClinicaNuevoRosario.Application.Helpers;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.Filter
{
    internal class FilterQuery : IRequest<List<AppointmentDto>>
    {
        public ServiceTypes? ServiceType { get; set; }
        public int? MedicalSpecialityId { get; set; }
        public int? HealthInsuranceId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
