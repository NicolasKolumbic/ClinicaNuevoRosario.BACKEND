using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByDoctor;
using ClinicaNuevoRosario.Application.Features.MedicalHistories.Queries.GetMedicalHistoriesByPatientAndDoctor;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Application.Models.MedicalHistories;
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
    public class MedicalHistoryController : Controller
    {
        private readonly IMediator _mediator;


        public MedicalHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetMedicalHistoriesByPatient")]
        [Authorize(Roles = "Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MedicalHistoryDto>>> GetMedicalHistoriesByPatient(int patientId, int doctorId)
        {
            var query = new GetMedicalHistoriesByPatientAndDoctorQuery() { PatientId = patientId, DoctorId = doctorId };
            return await _mediator.Send(query);
        }
    }
}
