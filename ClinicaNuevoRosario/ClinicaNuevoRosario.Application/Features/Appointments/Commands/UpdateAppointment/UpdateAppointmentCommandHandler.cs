using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Exceptions;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment
{

    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAppointmentCommandHandler> _logger;

        public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, ILogger<UpdateAppointmentCommandHandler> logger)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                _logger.LogError($"No se encontrado el una persona con id: {request.AppointmentId}");
                throw new NotFoundException(nameof(Appointment), request.AppointmentId);
            }

            _mapper.Map(request, appointment, typeof(UpdateAppointmentCommand), typeof(Appointment));
            var updatedAppointment = await _appointmentRepository.UpdateAsync(appointment);
            _logger.LogInformation($"Cita: {updatedAppointment} fue actualizado correctamente");

            return updatedAppointment.Id;
        }
    }
}
