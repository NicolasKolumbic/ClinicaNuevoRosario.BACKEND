using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
    {
        public PlanRepository(CNRDBContext context) : base(context)
        {
        }

        public Task<IQueryable<Plan>> GetByList(List<int> plansIds)
        {
            var plans = this._context.Plan;

            var result = (from d in plans
                          where plansIds.Contains(d.Id)
                          select d);

            return Task.FromResult(result);
        }
    }
}
