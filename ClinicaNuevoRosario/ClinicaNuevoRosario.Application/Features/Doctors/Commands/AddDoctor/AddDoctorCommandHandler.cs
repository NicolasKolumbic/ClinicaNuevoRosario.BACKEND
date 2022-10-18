using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.External;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, int>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMedicalSpecialitiesRepository _medicalSpecialitiesRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddDoctorCommandHandler> _logger;

        public AddDoctorCommandHandler(
            IDoctorRepository doctorRepository,
            IMedicalSpecialitiesRepository medicalSpecialitiesRepository,
            IPlanRepository planRepository,
            IEmailService emailService,
            IMapper mapper,
            ILogger<AddDoctorCommandHandler> logger)
        {
            _doctorRepository = doctorRepository;
            _medicalSpecialitiesRepository = medicalSpecialitiesRepository;
            _planRepository = planRepository;
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctorEntity = _mapper.Map<Doctor>(request.Doctor);
            var medicalSpecialities = await GetMedicalSpecialitiesEntities(request.Doctor.MedicalSpecialties);
            var plans = await GetPlansEntities(request.Doctor.Plans);
            doctorEntity.MedicalSpecialties.AddRange(medicalSpecialities);
            doctorEntity.Plans.AddRange(plans);
            var addedDoctor = await _doctorRepository.AddAsync(doctorEntity);
            _logger.LogInformation($"Doctor: {addedDoctor} fue creado correctamente");

           // await SendEmail(addedDoctor);

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

        private async Task<List<MedicalSpecialty>> GetMedicalSpecialitiesEntities(List<MedicalSpecialtyDto> medicalSpecialtyDtos)
        {
            var ids = medicalSpecialtyDtos.Select(ms => ms.MedicalSpecialtyId).ToList();
            var result =  await _medicalSpecialitiesRepository.GetByList(ids);
            return result.AsEnumerable().ToList();
        }

        private async Task<List<Plan>> GetPlansEntities(List<PlanDto> plansDtos)
        {
            var ids = plansDtos.Select(ms => ms.Id).ToList();
            var result = await _planRepository.GetByList(ids);
            return result.AsEnumerable().ToList();
        }
    }
}
