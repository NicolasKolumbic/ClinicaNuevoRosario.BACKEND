using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Exceptions;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteAppointmentCommandHandler> _logger;

        public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, ILogger<DeleteAppointmentCommandHandler> logger)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                _logger.LogError($"Not found streamer with id {request.AppointmentId}");
                throw new NotFoundException(nameof(Appointment), request.AppointmentId);
            }

            await _appointmentRepository.DeleteAsync(appointment);

            return request.AppointmentId;
        }
    }
}
