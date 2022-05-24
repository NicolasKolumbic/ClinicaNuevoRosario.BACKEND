namespace ClinicaNuevoRosario.Domain
{
    public class Doctor: Person
    {
        public string MedicalLicense { get; set; }   
        public bool IsActive { get; set; }
    }
}
