using ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.DeleteDoctor;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.UpdateDoctor;
using ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetAllDoctors;
using ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetAllMedicalSpecialities;
using ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetDoctorsByMedicalSpeciality;
using ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchDoctors;
using ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchMedicalSpeciality;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaNuevoRosario.API.Controllers
{

    [Authorize]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/v1/[controller]/[action]")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles ="Administrativo")]
        [HttpGet(Name = "AllDoctors")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorDto>>> GetAllDoctors()
        {
            var query = new GetAllDoctorsQuery();
            return await _mediator.Send(query);
        }

        [Authorize(Roles = "Administrativo")]
        [HttpGet(Name = "SearchDoctor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorDto>>> SearchDoctor(string text)
        {
            var query = new SearchDoctorsQuery() { Text = text};
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "AddDoctor")]
        [Authorize(Roles = "Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddDoctor([FromBody] AddDoctorCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateDoctor")]
        [Authorize(Roles = "Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateDoctor([FromBody] UpdateDoctorCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete(Name = "DeleteDoctor")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteDoctor([FromBody] DeleteDoctorCommand command)
        {
            return await _mediator.Send(command);
        }

        [Authorize(Roles = "Administrativo,Medico")]
        [HttpGet(Name = "AllMedicalSpecial")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MedicalSpecialtyDto>>> AllMedicalSpecial()
        {
            var query = new GetAllMedicalSpecialitiesQuery();
            return await _mediator.Send(query);
        }


        [HttpGet(Name = "SearchMedicalSpecial")]
        [Authorize(Roles = "Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MedicalSpecialtyDto>>> SearchMedicalSpecial(string text)
        {
            var query = new SearchMedicalSpecialityQuery() { Text = text};
            return await _mediator.Send(query);
        }

        [HttpGet(Name = "GetDoctorsByMedicalSpeciality")]
        [Authorize(Roles = "Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorDto>>> GetDoctorsByMedicalSpeciality(int medicalSpecialityId)
        {
            var query = new GetDoctorsByMedicalSpecialityQuery() { MedicalSpecialityId = medicalSpecialityId };
            return await _mediator.Send(query);
        }
    }
}
