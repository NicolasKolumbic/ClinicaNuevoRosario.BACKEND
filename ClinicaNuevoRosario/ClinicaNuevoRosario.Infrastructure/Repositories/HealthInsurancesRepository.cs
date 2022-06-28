using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class HealthInsurancesRepository : RepositoryBase<HealthInsurance>, IHealthInsurancesRepository
    {
        public HealthInsurancesRepository(CNRDBContext context) : base(context)
        {
        }
    }
}
