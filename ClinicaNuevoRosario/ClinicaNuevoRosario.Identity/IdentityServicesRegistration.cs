using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Application.Mappings;
using ClinicaNuevoRosario.Application.Models.Identity;
using ClinicaNuevoRosario.Application.Models.User;
using ClinicaNuevoRosario.Identity.Models;
using ClinicaNuevoRosario.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClinicaNuevoRosario.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JwtSetting"));
            services.AddDbContext<CNRIdentityDbContext>(options =>
                options.UseSqlServer(
                                        configuration.GetConnectionString("IdentityConnectionString"),
                                        _ef => _ef.MigrationsAssembly(typeof(CNRIdentityDbContext).Assembly.FullName)
                                    )
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(opt => {
                opt.Password.RequiredLength = 16;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<CNRIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService<ApplicationUser, UserChat>, UserService>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSetting:Issuer"],
                    ValidAudience = configuration["JwtSetting:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"]))
                };
            });

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

            return services;
        }
    }
}
