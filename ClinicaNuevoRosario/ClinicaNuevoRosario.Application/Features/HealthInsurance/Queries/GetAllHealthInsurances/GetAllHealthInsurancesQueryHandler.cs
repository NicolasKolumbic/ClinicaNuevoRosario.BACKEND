using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllHealthInsurances
{
    public class GetAllHealthInsurancesQueryHandler : IRequestHandler<GetAllHealthInsurancesQuery, List<HealthInsuranceDto>>
    {
        private readonly IHealthInsurancesRepository _healthInsurancesRepository;
        private readonly IMapper _mapper;

        public GetAllHealthInsurancesQueryHandler(IHealthInsurancesRepository healthInsurancesRepository, IMapper mapper)
        {
            _healthInsurancesRepository = healthInsurancesRepository;
            _mapper = mapper;
        }

        public async Task<List<HealthInsuranceDto>> Handle(GetAllHealthInsurancesQuery request, CancellationToken cancellationToken)
        {
            var healthInsurances = await _healthInsurancesRepository.GetAllAsync();
            return _mapper.Map<List<HealthInsuranceDto>>(healthInsurances.ToList());
        }
    }
}
