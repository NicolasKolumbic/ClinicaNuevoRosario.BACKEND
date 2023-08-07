using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.MedicalHistories;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.MedicalHistories.Queries.GetMedicalHistoriesByPatientAndDoctor
{
    public class GetMedicalHistoriesByPatientAndDoctorQueryHandler : IRequestHandler<GetMedicalHistoriesByPatientAndDoctorQuery, List<MedicalHistoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public GetMedicalHistoriesByPatientAndDoctorQueryHandler(IMapper mapper, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _mapper = mapper;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<List<MedicalHistoryDto>> Handle(GetMedicalHistoriesByPatientAndDoctorQuery request, CancellationToken cancellationToken)
        {
            var medicalHistories = await this._medicalHistoryRepository.GetAsync(medicalHistory => medicalHistory.DoctorId == request.DoctorId && medicalHistory.PatientId == request.PatientId);
            return  _mapper.Map<List<MedicalHistoryDto>>(medicalHistories).ToList();
        }
    }
}
