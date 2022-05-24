using Microsoft.EntityFrameworkCore;

namespace ClinicaNuevoRosario.Domain
{
    [Keyless]
    public class DoctorMedicalSpecialty
    {
        public int DoctorId { get; set; }
        public int MedicalSpecialtyId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual MedicalSpecialty MedicalSpecialty { get; set; }
    }
}
