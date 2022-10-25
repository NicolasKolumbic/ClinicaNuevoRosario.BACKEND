using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllHealthInsurances;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllPlans
{
    public class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, List<GetPlanDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPlanRepository _planRepository;

        public GetAllPlansQueryHandler(IMapper mapper, IPlanRepository planRepository)
        {
            _mapper = mapper;
            _planRepository = planRepository;
        }

        public async Task<List<GetPlanDto>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
            var plans =  await _planRepository.GetAllAsync("HealthInsurance");
            return _mapper.Map<List<GetPlanDto>>(plans);
        }
    }
}
