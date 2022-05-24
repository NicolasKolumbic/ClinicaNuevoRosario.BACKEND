using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{
    public class DoctorSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Day { get; set; } = String.Empty;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
