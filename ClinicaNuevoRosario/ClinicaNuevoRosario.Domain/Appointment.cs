using ClinicaNuevoRosario.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{
    public class Appointment: BaseDomainModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int DoctorId { get; set; }
        public int HealthInsuranceId { get; set; }

        public int PatientId { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Comments { get; set; } = string.Empty;
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual HealthInsurance? HealthInsurance { get; set; }
    }
}
