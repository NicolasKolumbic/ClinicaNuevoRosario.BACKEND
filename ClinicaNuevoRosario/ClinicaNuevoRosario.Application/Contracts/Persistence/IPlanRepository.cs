using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IPlanRepository: IAsyncRepository<Plan>
    {
        public Task<IQueryable<Plan>> GetByList(List<int> medicalSpecialtiesIds);

    }
}
