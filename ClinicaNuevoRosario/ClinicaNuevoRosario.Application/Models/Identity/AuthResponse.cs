namespace ClinicaNuevoRosario.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public double ExpireIn { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public List<string> Roles { get; set; } = new List<string>();

    }
}
