using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Application.Models.Pantients;
using ClinicaNuevoRosario.Domain;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommand: IRequest<int>
    {
        public DateTime Time { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }
        public bool IsActive { get; set; } = true;
        public string Comments { get; set; } = string.Empty;
    }
}
