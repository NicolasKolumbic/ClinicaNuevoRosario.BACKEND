using ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetAllDoctors;
using ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllHealthInsurances;
using ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllPlans;
using ClinicaNuevoRosario.Application.Models.Doctors;
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
    public class HealthInsuranceController : Controller
    {
        private readonly IMediator _mediator;

        public HealthInsuranceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "AllPlans")]
        [Authorize(Roles ="Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetPlanDto>>> GetAllPlans()
        {
            var query = new GetAllPlansQuery();
            return await _mediator.Send(query);
        }
    }
}
