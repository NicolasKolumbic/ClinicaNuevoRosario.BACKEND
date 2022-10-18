namespace ClinicaNuevoRosario.Domain
{
    public class Patient: Person
    {
        public int? PlanId { get; set; }
        public virtual Plan Plan { get; set; }   
    }
}
