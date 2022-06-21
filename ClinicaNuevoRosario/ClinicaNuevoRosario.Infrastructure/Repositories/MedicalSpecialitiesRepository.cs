using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class MedicalSpecialitiesRepository : RepositoryBase<MedicalSpecialty>, IMedicalSpecialitiesRepository
    {
        public MedicalSpecialitiesRepository(CNRDBContext context) : base(context)
        {
        }

        public Task<IQueryable<MedicalSpecialty>> GetByName(string name)
        {
            var medicalSpecialties = this._context.MedicalSpecialties;

            var result = (from d in medicalSpecialties
                          where d.Name.Contains(name)
                          select d);

            return Task.FromResult(result);
        }
    }
}
