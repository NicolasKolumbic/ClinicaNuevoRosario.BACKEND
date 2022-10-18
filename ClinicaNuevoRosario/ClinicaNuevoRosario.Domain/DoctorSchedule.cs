using ClinicaNuevoRosario.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{
    public class DoctorSchedule: BaseDomainModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int? AppointmentDuration { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}
