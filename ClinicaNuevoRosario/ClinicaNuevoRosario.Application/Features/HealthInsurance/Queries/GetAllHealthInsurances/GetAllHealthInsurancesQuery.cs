using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.HealthInsurance.Queries.GetAllHealthInsurances
{
    public class GetAllHealthInsurancesQuery: IRequest<List<HealthInsuranceDto>>
    {
    }
}
