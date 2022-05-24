namespace ClinicaNuevoRosario.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
