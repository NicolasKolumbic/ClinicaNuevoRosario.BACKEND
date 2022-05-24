using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommand: IRequest<int>
    {
        public DateTime Time { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int HealthInsuranceId { get; set; }
        public bool IsActive { get; set; } = true;
        public string Comments { get; set; } = string.Empty;
    }
}
