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
        public int PatientId { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? AppointmentStateId { get; set; }
        public string? Comments { get; set; } = string.Empty;
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual AppointmentState AppointmentState { get; set; }

    }
}
