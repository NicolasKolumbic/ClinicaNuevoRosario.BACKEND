using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IPatientRepository: IAsyncRepository<Patient>
    {
       public Task<IQueryable<Patient>> GetByName(string name);

    }
}
