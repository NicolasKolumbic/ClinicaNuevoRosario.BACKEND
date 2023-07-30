using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByEmail
{
    public class GetAppointmentsByEmailQuery: IRequest<List<AppointmentDto>>
    {
        public string Email { get; set; }
    }
}
