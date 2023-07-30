namespace ClinicaNuevoRosario.Identity.Models
{
    public class UserChat
    {
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public UserChat(ApplicationUser user)
        {
            this.Name = user.Name;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }
    }
}
