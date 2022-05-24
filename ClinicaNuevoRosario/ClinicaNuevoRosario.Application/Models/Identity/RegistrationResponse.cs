namespace ClinicaNuevoRosario.Application.Models.Identity
{
    public class RegistrationResponse
    {
        public string UserId { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;

    }
}
