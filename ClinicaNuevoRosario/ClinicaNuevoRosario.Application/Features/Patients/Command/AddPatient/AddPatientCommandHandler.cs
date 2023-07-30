using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Patients.Command.AddPatient
{
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, int>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddPatientCommandHandler> _logger;

        public AddPatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, ILogger<AddPatientCommandHandler> logger)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patientEntity = _mapper.Map<Patient>(request);
            var addedPatient = await _patientRepository.AddAsync(patientEntity);
            _logger.LogInformation($"Paciente: {addedPatient} fue creado correctamente");

            return addedPatient.Id;
        }
    }
}
