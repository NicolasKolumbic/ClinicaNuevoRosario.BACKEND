using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{
    public class Doctor: Person
    {
        public Doctor()
        {
            DoctorSchedules = new List<DoctorSchedule>();
            DoctorMedicalSpecialties = new List<DoctorMedicalSpecialty>();
        }

        public string MedicalLicense { get; set; } = String.Empty;  
        public bool IsActive { get; set; }
        public int AppointmentDurationDefault { get; set; } = 15;
        public virtual List<DoctorSchedule>? DoctorSchedules { get; set; }
        public virtual List<DoctorMedicalSpecialty>? DoctorMedicalSpecialties { get; set; }

    }
}
