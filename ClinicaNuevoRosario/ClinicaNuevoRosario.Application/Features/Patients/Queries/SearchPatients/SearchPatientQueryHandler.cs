using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Pantients;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Patients.Queries.SearchPatients
{
    public class SearchPatientQueryHandler : IRequestHandler<SearchPatientQuery, List<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public SearchPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> Handle(SearchPatientQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetByName(request.Text);
            var patientsViewModel = _mapper.Map<List<PatientDto>>(patients.ToList());
            return patientsViewModel;
        }
    }
}
