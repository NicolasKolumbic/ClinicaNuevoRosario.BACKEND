using ClinicaNuevoRosario.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{

    public class DoctorMedicalSpecialty : BaseDomainModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int MedicalSpecialtyId { get; set; }

        public MedicalSpecialty MedicalSpecialty { get; set; }

    }
}
