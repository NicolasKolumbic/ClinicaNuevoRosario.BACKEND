using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByEmailQueryHandler : IRequestHandler<GetDoctorByEmailQuery, DoctorDto>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetDoctorByEmailQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Handle(GetDoctorByEmailQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetDoctorByEmail(request.Email);
            var doctorsViewModel = _mapper.Map<DoctorDto>(doctors);
            return doctorsViewModel;
        }
    }
}
