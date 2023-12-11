using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAllAppointments;
using ClinicaNuevoRosario.Application.Features.BackupRestore;
using ClinicaNuevoRosario.Application.Features.BackupRestore.Command;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.IO;
using System.Net;

namespace ClinicaNuevoRosario.API.Controllers
{
    [Authorize]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/v1/[controller]/[action]")]
    public class AdministratorController : Controller
    {

        private readonly IMediator _mediator;

        public AdministratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "GenerateBackupDatabase")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GenerateBackupDatabase([FromBody] GenerateBackupDatabaseQuery query)
        {
            var memoryStream = await _mediator.Send(query);
            return File(memoryStream, "application/octet-stream", query.fileName);
        }

        [HttpPost(Name = "RestoreDatabase"), DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(Roles = "Administrador")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> RestoreDatabase([FromForm] RestoreDatabaseCommand command)
        {
            var value = await _mediator.Send(command);
            return Ok(value);
        }
    }
}
