using ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.DeleteAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.AppointmentsFilter;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GeAvailableAppointmentsByDoctorId;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAllAppointments;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentById;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByDoctor;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByEmail;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByHealthInsuranceId;
using ClinicaNuevoRosario.Application.Features.ReportGenerator.Command;
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
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;


        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AllAppointments")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(Roles = "Administrativo")]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointments()
        {
            var query = new GetAllAppointmentsQuery();
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "AddAppointment")]
        [Authorize(Roles = "Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddAppointment([FromBody] AddAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateAppointment")]
        [Authorize(Roles = "Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateAppointment([FromBody] UpdateAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete(Name = "DeleteAppointment")]
        [Authorize(Roles = "Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteAppointment([FromBody] DeleteAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet(Name = "GetAppointmentsByDoctorId")]
        [Authorize(Roles = "Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentsByDoctorId(int doctorId)
        {
            var query = new GetAppointmentsByDoctorQuery() { DoctorId = doctorId};
            return await _mediator.Send(query);
        }

        [HttpGet(Name = "GetAppointmentsByEmail")]
        [Authorize(Roles = "Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentsByEmail(string email)
        {
            var query = new GetAppointmentsByEmailQuery() { Email = email };
            return await _mediator.Send(query);
        }

        [HttpGet(Name = "GetAppointmentsByHealthInsuranceId")]
        [Authorize(Roles = "Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentsByHealthInsuranceId(int healthInsuranceId)
        {
            var query = new GetAppointmentsByHealthInsuranceQuery() { HealthInsuranceId = healthInsuranceId };
            return await _mediator.Send(query);
        }

        [HttpGet(Name = "GetAppointmentsById")]
        [Authorize(Roles = "Medico,Administrativo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppointmentDto>> GetAppointmentsById(int appointmentId)
        {
            var query = new GetAppointmentByIdQuery() { AppointmentId = appointmentId };
            return await _mediator.Send(query);
        }

        [HttpGet(Name = "GetAllAppointments")]
        [Authorize(Roles = "Medico,Administrativo,Contable,Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AppointmentDto>>> GetAllAppointments()
        {
            var query = new GetAllAppointmentsQuery();
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "ReportGenerator")]
        [Authorize(Roles = "Contable")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> ReportGenerator([FromBody] ReportGeneratorCommand command)
        {
            var file = await _mediator.Send(command);
            return File(file, "application/pdf");
        }

        [HttpPost(Name = "AppointmentsFilter")]
        [Authorize(Roles = "Contable,Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AppointmentDto>>> AppointmentsFilter([FromBody] AppointmentsFilterQuery query)
        {
            return await _mediator.Send(query);
        }

        
        [HttpGet(Name = "GetAssignedAppointmentByDoctorId")]
        [Authorize(Roles = "Administrativo,Medico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AppointmentDto>>> GetAssignedAppointmentByDoctorId(int doctorId)
        {
            var query = new GetAssignedAppointmentByDoctorIdQuery() { DoctorId = doctorId };
            return await _mediator.Send(query);
        }


    }
}

