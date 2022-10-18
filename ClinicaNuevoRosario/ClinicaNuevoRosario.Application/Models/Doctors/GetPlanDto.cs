namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class GetPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GetHealthInsuranceDto HealthInsurance { get; set; }
    }
}
