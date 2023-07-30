using ClinicaNuevoRosario.Application.Helpers;
using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Time { get; set; }
        public string? Comments { get; set; } = string.Empty;
        public DoctorDto Doctor { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
        public Patient Patient { get; set; }
        public List<MedicalHistory>? MedicalHistories { get; set; }
        public ServiceTypes ServiceType { get; set; }
        public AppointmentStates AppointmentState { get; set; }
    }
}
