using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand: IRequest<int>
    {
        public int AppointmentId { get; set; }
        public DateTime Time { get; set; }
        public int DoctorId { get; set; }
        public int PatientId{ get; set; }
        public int HealthInsuranceId { get; set; }

        public string Comments { get; set; } = string.Empty;
    }
}
