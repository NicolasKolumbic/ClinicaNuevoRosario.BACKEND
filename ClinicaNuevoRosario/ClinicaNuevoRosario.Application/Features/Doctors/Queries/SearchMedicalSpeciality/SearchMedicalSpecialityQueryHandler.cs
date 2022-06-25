using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchMedicalSpeciality
{
    public class SearchMedicalSpecialityQueryHandler : IRequestHandler<SearchMedicalSpecialityQuery, List<MedicalSpecialtyDto>>
    {
        private readonly IMedicalSpecialitiesRepository _medicalSpecialitiesRepository;
        private readonly IMapper _mapper;

        public SearchMedicalSpecialityQueryHandler(IMedicalSpecialitiesRepository medicalSpecialitiesRepository, IMapper mapper)
        {
            _medicalSpecialitiesRepository = medicalSpecialitiesRepository;
            _mapper = mapper;
        }

        public async Task<List<MedicalSpecialtyDto>> Handle(SearchMedicalSpecialityQuery request, CancellationToken cancellationToken)
        {
            var medicalSpecialties = await _medicalSpecialitiesRepository.GetByName(request.Text);
            var medicalSpeacialityResponses = _mapper.Map<List<MedicalSpecialtyDto>>(medicalSpecialties.ToList());
            return medicalSpeacialityResponses;
        }
    }
}
