using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaNuevoRosario.API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/v1/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService<ApplicationUser, UserChat> _userService;

        public UserController(IUserService<ApplicationUser, UserChat> userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUsersChat")]
        [Authorize(Roles = "Medico,Contable,Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<UserChat>>> GetUsersChat()
        {
            return await _userService.GetUsersAsync();
        }

    }
}
