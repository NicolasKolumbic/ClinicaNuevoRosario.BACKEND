namespace ClinicaNuevoRosario.Domain
{
    public class Patient: Person
    {
        public int? HealthInsuranceId { get; set; }
        public virtual HealthInsurance HealthInsurance { get; set; }
        public int? PlanId { get; set; }
        public virtual Plan Plan { get; set; }

       
    }
}
