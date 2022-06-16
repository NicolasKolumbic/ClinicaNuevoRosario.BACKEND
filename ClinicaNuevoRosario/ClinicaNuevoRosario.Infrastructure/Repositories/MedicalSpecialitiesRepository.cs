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
    }
}
