using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.External;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, int>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddDoctorCommandHandler> _logger;

        public AddDoctorCommandHandler(IDoctorRepository doctorRepository, IEmailService emailService, IMapper mapper, ILogger<AddDoctorCommandHandler> logger)
        {
            _doctorRepository = doctorRepository;
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctorEntity = _mapper.Map<Doctor>(request);
            var addedDoctor = await _doctorRepository.AddAsync(doctorEntity);
            _logger.LogInformation($"Doctor: {addedDoctor} fue creado correctamente");

            await SendEmail(addedDoctor);

            return addedDoctor.Id;
        }

        private async Task SendEmail(Doctor doctor)
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
