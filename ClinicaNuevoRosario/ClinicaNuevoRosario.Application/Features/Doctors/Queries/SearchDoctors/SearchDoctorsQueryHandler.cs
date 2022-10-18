using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchDoctors
{
    public class SearchDoctorsQueryHandler : IRequestHandler<SearchDoctorsQuery, List<DoctorDto>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public SearchDoctorsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> Handle(SearchDoctorsQuery request, CancellationToken cancellationToken)
        {
            if(request.DoctorCriteria != null)
            {
                var doctors = await _doctorRepository.GetByName(request.DoctorCriteria);
                return _mapper.Map<List<DoctorDto>>(doctors.ToList());
            } else if(request.MedicalSpecialty != null || request.Plan != null)
            {
                var doctors = await _doctorRepository.GetByMedicalSpecialityOrHealthInsurance(request.MedicalSpecialty?.MedicalSpecialtyId, request.Plan?.Id);
                return _mapper.Map<List<DoctorDto>>(doctors.ToList());
            }
            
           
            return new List<DoctorDto>();
        }
    }
}
