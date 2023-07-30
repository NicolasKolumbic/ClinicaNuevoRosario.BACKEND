using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaNuevoRosario.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "d2c01424-3245-4dff-abb4-51086fb6f897",
                UserId = "3600fe5c-e3f3-4e0f-9bf4-e98d32eb5e12"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d2c01424-3245-4dff-abb4-51086fb6f897",
                UserId = "a3ec6212-26ef-4871-b13f-7e7c8d8c5101"
            }
            );
        }
    }
}
