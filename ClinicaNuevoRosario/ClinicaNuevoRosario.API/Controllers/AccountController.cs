using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Application.Models.Identity;
using ClinicaNuevoRosario.Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaNuevoRosario.API.Controllers
{
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            var result = await _authService.Login(request);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            var result = await _authService.Register(request);
            return Ok(result);
        }

        [HttpPost("RecoverPassword")]
        public async Task RecoverPassword([FromBody] string email)
        {
            await _authService.RecoverPassword(email);
        }

        [HttpPost("ResetPassword")]
        public async Task ResetPassword([FromBody] ResetPassword resetPassword)
        {
            await _authService.ResetPassword(resetPassword);
        }
    }
}
