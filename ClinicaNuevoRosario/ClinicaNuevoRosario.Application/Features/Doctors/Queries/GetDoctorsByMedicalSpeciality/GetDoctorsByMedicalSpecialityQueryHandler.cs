using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetDoctorsByMedicalSpeciality
{
    public class GetDoctorsByMedicalSpecialityQueryHandler : IRequestHandler<GetDoctorsByMedicalSpecialityQuery, List<DoctorDto>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetDoctorsByMedicalSpecialityQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> Handle(GetDoctorsByMedicalSpecialityQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetByMedicalSpeciality(request.MedicalSpecialityId);
            var doctorsViewModel = _mapper.Map<List<DoctorDto>>(doctors.ToList());
            return doctorsViewModel;
        }
    }
}
