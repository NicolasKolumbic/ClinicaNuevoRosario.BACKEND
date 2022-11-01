using ClinicaNuevoRosario.Application.Consts;
using ClinicaNuevoRosario.Application.Contracts.External;
using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Application.Models.Identity;
using ClinicaNuevoRosario.Application.Models.User;
using ClinicaNuevoRosario.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicaNuevoRosario.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IEmailService _emailService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JWTSettings> jwtSettings,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _emailService = emailService;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new Exception($"El usuario con email {request.Email} no existe");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Las Crendenciales son erroneaas");
            }
            var token = await GenerateToken(user);

            var response = new AuthResponse();
            response.Id = user.Id;
            response.Name = user.Name;
            response.LastName = user.LastName;
            response.ExpireIn = this._jwtSettings.DurationInMinutes;
            response.Email = user.Email;
            response.Token = new JwtSecurityTokenHandler().WriteToken(token);
            response.Roles = (await _userManager.GetRolesAsync(user)).ToList();

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new Exception($"El email existe");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                EmailConfirmed = true,
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            var token = await GenerateToken(user);

            if (result.Succeeded)
            {  
                await _userManager.AddToRoleAsync(user, "Básico");
                return new RegistrationResponse
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id
                };
            }

            throw new Exception($"Errors: {result.Errors}");

        }

        public async Task<RecoverPasswordResponse> RecoverPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new Exception($"El usuario con email {email} no existe");
            }

            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var recoverPasswordResponse = new RecoverPasswordResponse();
            recoverPasswordResponse.Email = user.Email;
            recoverPasswordResponse.Token = passwordResetToken is null ? String.Empty : passwordResetToken;

           return recoverPasswordResponse;


        }

        public async Task ResetPassword(ResetPassword resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user is null)
            {
                throw new Exception($"El usuario con email {resetPassword.Email} no existe");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.ConfirmPassword);
            if (!result.Succeeded)
            {
                throw new Exception("No se ha podido reestablecer su contraseña");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var rolesClaims = new List<Claim>();

            foreach (var role in roles)
            {
                rolesClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimType.Uid, user.Id),
            }.Union(userClaims).Union(rolesClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var singInCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                signingCredentials: singInCredential,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes)
            );

            return jwtSecurityToken;
        }
    }
}
