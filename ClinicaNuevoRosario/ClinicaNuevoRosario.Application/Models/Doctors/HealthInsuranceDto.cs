namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class HealthInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public ICollection<PlanDto> Plans { get; set; }
        
    }
}
