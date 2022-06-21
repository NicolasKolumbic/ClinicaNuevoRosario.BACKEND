namespace ClinicaNuevoRosario.Application.Models.Pantients
{
    public class PantientResponse
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public double IdentificationNumber { get; set; }
    }
}
