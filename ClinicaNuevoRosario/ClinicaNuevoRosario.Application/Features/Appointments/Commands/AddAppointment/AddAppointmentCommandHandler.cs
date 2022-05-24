using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.External;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddAppointmentCommandHandler> _logger;

        public AddAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IEmailService emailService, IMapper mapper, ILogger<AddAppointmentCommandHandler> logger)
        {
            _appointmentRepository = appointmentRepository;
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentEntity = _mapper.Map<Appointment>(request);
            var addedAppointment = await _appointmentRepository.AddAsync(appointmentEntity);
            _logger.LogInformation($"Doctor: {addedAppointment} fue creado correctamente");

            await SendEmail(addedAppointment);

            return addedAppointment.Id;
        }

        private async Task SendEmail(Appointment appointment)
        {
            var email = new Email
            {
                Body = $"Ha sido agregado al staff de profesionales de Clínica Nuevo Rosario",
                Subject = $"Confirmación",
                To = $"nicolaskolumbic@hotmail.com"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }


        }
    }
}
