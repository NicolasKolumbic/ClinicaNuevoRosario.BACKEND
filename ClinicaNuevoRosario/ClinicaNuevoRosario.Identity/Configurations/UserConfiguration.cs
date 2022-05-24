using ClinicaNuevoRosario.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaNuevoRosario.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(new ApplicationUser()
            {
                Id = "3600fe5c-e3f3-4e0f-9bf4-e98d32eb5e12",
                UserName = "nkolumbic",
                NormalizedUserName = "NKOLUMBIC",
                Email = "nicolaskolumbic@hotmail.com",
                NormalizedEmail = "nicolaskolumbic@hotmail.com",
                Name = "Nicolás",
                LastName = "Kolumbic",
                PasswordHash = hasher.HashPassword(null, "trabajocampo1234!"),
                EmailConfirmed = true
            }, new ApplicationUser
            {
                Id = "a3ec6212-26ef-4871-b13f-7e7c8d8c5101",
                UserName = "gbarbero",
                NormalizedUserName = "gbarbero",
                Email = "gastonbarbero@hotmail.com",
                NormalizedEmail = "gastonbarbero@hotmail.com",
                Name = "Gastón",
                LastName = "Barbero",
                PasswordHash = hasher.HashPassword(null, "trabajocampo1234!"),
                EmailConfirmed = true
            });
        }
    }
}
