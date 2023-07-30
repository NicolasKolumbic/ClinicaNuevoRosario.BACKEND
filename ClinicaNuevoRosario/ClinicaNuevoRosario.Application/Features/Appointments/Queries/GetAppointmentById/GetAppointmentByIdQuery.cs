using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQuery: IRequest<AppointmentDto>
    {
        public int AppointmentId { get; set; }
    }
}
