using ClinicaNuevoRosario.Application.Helpers;
using ClinicaNuevoRosario.Domain;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand: IRequest<int>
    {
        public int AppointmentId { get; set; }
        public string? MedicalHistoryComment { get; set; }
        public AppointmentStates AppointmentState { get; set; }
    }
}
