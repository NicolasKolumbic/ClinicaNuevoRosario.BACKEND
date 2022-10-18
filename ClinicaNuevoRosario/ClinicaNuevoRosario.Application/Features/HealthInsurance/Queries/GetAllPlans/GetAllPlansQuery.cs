using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllPlans
{
    public class GetAllPlansQuery: IRequest<List<GetPlanDto>>
    {
    }
}
