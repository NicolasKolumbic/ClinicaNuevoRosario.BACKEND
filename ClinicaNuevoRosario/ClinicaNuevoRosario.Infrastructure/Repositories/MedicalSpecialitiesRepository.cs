using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using System.Xml.Linq;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class MedicalSpecialitiesRepository : RepositoryBase<MedicalSpecialty>, IMedicalSpecialitiesRepository
    {
        public MedicalSpecialitiesRepository(CNRDBContext context) : base(context)
        {
        }

        public Task<IQueryable<MedicalSpecialty>> GetByList(List<int> medicalSpecialtiesIds)
        {
            var medicalSpecialties = this._context.MedicalSpecialties;

            var result = (from d in medicalSpecialties
                          where medicalSpecialtiesIds.Contains(d.Id)
                          select d);

            return Task.FromResult(result);
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
