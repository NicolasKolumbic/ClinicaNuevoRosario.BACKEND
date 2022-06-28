using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IHealthInsurancesRepository: IAsyncRepository<HealthInsurance>
    {
    }
}
