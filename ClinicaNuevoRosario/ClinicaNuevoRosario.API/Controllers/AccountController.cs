using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Application.Models.Identity;
using ClinicaNuevoRosario.Application.Models.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaNuevoRosario.API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/v1/[controller]/[action]")]
    public class AccountController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(Name = "Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            var result = await _authService.Login(request);
            return Ok(result);
        }

        [HttpPost(Name = "Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            var result = await _authService.Register(request);
            return Ok(result);
        }

        [HttpPost(Name = "RecoverPassword")]
        public async Task<RecoverPasswordResponse> RecoverPassword([FromForm] string email)
        {
            return await _authService.RecoverPassword(email);
        }

        [HttpPost(Name = "ResetPassword")]
        public async Task ResetPassword([FromBody] ResetPassword resetPassword)
        {
            await _authService.ResetPassword(resetPassword);
        }

        [HttpPost(Name = "AssignRole")]
        public async Task<ActionResult<AuthResponse>> AssignRole([FromBody] RoleUserUpdateRequest request)
        {
            var result = await _authService.AssignRole(request.Email, request.Role);
            return Ok(result);
        }
    }
}
