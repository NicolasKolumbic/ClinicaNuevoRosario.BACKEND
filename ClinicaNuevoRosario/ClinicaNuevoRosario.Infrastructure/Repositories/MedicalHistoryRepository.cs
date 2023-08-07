using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class MedicalHistoryRepository : RepositoryBase<MedicalHistory>, IMedicalHistoryRepository
    {
        public MedicalHistoryRepository(CNRDBContext context) : base(context)
        {
        }
    }
}
