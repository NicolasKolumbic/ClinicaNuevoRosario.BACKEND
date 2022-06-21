using ClinicaNuevoRosario.Application.Features.Patients.Queries.SearchPatients;
using ClinicaNuevoRosario.Application.Models.Pantients;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaNuevoRosario.API.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "SearchPatient")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PantientResponse>>> SearchPatient(string text)
        {
            var query = new SearchPatientQuery() { Text = text };
            return await _mediator.Send(query);
        }
    }
}
