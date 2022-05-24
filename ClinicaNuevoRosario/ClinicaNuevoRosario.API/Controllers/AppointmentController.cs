﻿using ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.DeleteAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAllAppointments;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaNuevoRosario.API.Controllers
{
    [ApiController]
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
        public async Task<ActionResult<List<AppointmentModel>>> GetAppointments()
        {
            var query = new GetAllAppointmentsQuery();
            return await _mediator.Send(query);
        }

        [HttpPost(Name = "AddAppointment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddAppointment([FromBody] AddAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateAppointment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateAppointment([FromBody] UpdateAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete(Name = "DeleteAppointment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteAppointment([FromBody] DeleteAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
