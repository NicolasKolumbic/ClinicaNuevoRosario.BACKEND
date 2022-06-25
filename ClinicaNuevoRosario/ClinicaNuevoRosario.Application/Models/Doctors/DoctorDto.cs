using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string MedicalLicense { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public double PhoneNumber { get; set; }
        public int AppointmentDurationDefault { get; set; }
        public List<DoctorScheduleDto>? DoctorSchedules { get; set; }
        public List<MedicalSpecialtyDto>? MedicalSpecialties { get; set; }
    }
}
