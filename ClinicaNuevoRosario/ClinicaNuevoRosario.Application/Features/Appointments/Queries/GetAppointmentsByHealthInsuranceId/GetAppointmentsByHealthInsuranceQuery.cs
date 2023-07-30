using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByHealthInsuranceId
{
    public class GetAppointmentsByHealthInsuranceQuery: IRequest<List<AppointmentDto>>
    {
        public int HealthInsuranceId { get; set; }
    }
}
