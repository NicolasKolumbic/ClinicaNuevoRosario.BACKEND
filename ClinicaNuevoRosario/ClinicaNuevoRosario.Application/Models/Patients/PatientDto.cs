using ClinicaNuevoRosario.Application.Models.Doctors;

namespace ClinicaNuevoRosario.Application.Models.Pantients
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public double IdentificationNumber { get; set; }
        public int? HealthInsurranceNumber { get; set; }
        public HealthInsuranceDto HealthInsurance { get; set; }
        public PlanDto Plan { get; set; }
    }
}
