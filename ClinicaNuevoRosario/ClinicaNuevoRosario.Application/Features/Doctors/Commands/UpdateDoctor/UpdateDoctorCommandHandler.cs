using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Exceptions;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, int>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDoctorCommandHandler> _logger;

        public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, ILogger<UpdateDoctorCommandHandler> logger)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);
            if (doctor == null)
            {
                _logger.LogError($"No se encontrado el una persona con id: {request.DoctorId}");
                throw new NotFoundException(nameof(Doctor), request.DoctorId);
            }

            _mapper.Map(request, doctor, typeof(UpdateDoctorCommand), typeof(Doctor));
            var updatedDoctor = await _doctorRepository.UpdateAsync(doctor);
            _logger.LogInformation($"Doctor: {updatedDoctor} fue actualizado correctamente");

            return updatedDoctor.Id;
        }
    }
}
