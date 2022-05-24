using Microsoft.AspNetCore.Identity;

namespace ClinicaNuevoRosario.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }  = String.Empty;
        public string LastName { get; set; } = String.Empty;

    }
}
