using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Comments { get; set; } = string.Empty;
        public Doctor Doctor { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
    }
}
