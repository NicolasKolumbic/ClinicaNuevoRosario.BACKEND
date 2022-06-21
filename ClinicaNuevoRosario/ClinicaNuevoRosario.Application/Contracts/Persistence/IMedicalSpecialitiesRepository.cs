using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IMedicalSpecialitiesRepository : IAsyncRepository<MedicalSpecialty>
    {
        public Task<IQueryable<MedicalSpecialty>> GetByName(string name);
    }
}
