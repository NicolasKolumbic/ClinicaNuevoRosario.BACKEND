using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Exceptions;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, int>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteDoctorCommandHandler> _logger;

        public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, ILogger<DeleteDoctorCommandHandler> logger)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);
            if (doctor == null)
            {
                _logger.LogError($"Not found streamer with id {request.DoctorId}");
                throw new NotFoundException(nameof(Doctor), request.DoctorId);
            }

            await _doctorRepository.DeleteAsync(doctor);

            return request.DoctorId;
        }
    }
}
