using ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllHealthInsurances;
using ClinicaNuevoRosario.Application.Features.Patients.Command.AddPatient;
using ClinicaNuevoRosario.Application.Features.Patients.Queries.SearchPatients;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Application.Models.Pantients;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaNuevoRosario.API.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "Administrativo,Medico")]
        public async Task<ActionResult<List<PatientDto>>> SearchPatient(string text)
        {
            var query = new SearchPatientQuery() { Text = text };
            return await _mediator.Send(query);
        }


        [HttpGet(Name = "GetAllHealthInsurances")]
        [Authorize(Roles = "Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<HealthInsuranceDto>>> GetAllHealthInsurances()
        {
            var query = new GetAllHealthInsurancesQuery();
            return await _mediator.Send(query);
        }


        [HttpPost(Name = "AddPatient")]
        [Authorize(Roles = "Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddPatient([FromBody] AddPatientCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
