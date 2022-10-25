﻿using ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.DeleteAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAllAppointments;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByDoctor;
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
        [Authorize(Roles = "Administrativo")]
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

    }
}

