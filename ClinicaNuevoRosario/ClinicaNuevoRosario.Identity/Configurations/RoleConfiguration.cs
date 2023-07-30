using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaNuevoRosario.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "d2c01424-3245-4dff-abb4-51086fb6f897",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            }, new IdentityRole
            {
                Id = "6f8b16d7-b2e4-420c-8c96-3ab021b11b78",
                Name = "Administrativo",
                NormalizedName = "ADMINISTRATIVO"
            },
            new IdentityRole
            {
                Id = "304ec0ad-f5dd-442f-ae18-ed26ef5feb27",
                Name = "Medico",
                NormalizedName = "MEDICO"
            },
            new IdentityRole
            {
                Id = "084136d8-c054-46d1-beb8-14ad1e647b2d",
                Name = "Visitante",
                NormalizedName = "VISITANTE"
            },
            new IdentityRole
            {
                Id = "30a33a14-23a6-447d-ae41-fbcbb7815f61",
                Name = "Contable",
                NormalizedName = "CONTABLE"
            });
        }
    }
}
