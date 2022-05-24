namespace ClinicaNuevoRosario.Application.Models.Identity
{
    public class JWTSettings
    {
        public string Key { get; set; } = String.Empty;
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public double DurationInMinutes { get; set; }
    }
}
