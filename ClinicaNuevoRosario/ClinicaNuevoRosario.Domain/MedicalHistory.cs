using ClinicaNuevoRosario.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{

    public class MedicalHistory: BaseDomainModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicalHistoryId { get; set; }
        public string Comments { get; set; }
        public  int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
