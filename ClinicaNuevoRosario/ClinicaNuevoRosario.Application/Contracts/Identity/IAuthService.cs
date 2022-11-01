using ClinicaNuevoRosario.Application.Models.Identity;
using ClinicaNuevoRosario.Application.Models.User;

namespace ClinicaNuevoRosario.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task ResetPassword(ResetPassword resetPassword);
        Task<RecoverPasswordResponse> RecoverPassword(string email);
    }
}
