namespace ClinicaNuevoRosario.Domain
{
    public class Employee: Person
    {
        public int ClinicRoleId { get; set; }
        public bool IsActive { get; set; }

        public virtual ClinicRole Role { get; set; }
    }
}
