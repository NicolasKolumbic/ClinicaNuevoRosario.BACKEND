using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand: IRequest<int>
    {
        public int AppointmentId { get; set; }
    }
}
