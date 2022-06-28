using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(CNRDBContext context) : base(context)
        {
        }

        public async Task<IQueryable<Patient>> GetByName(string name)
        {
            var result = _context.Patients
                .Include(p => p.HealthInsurance)
                .Include(p => p.Plan)
               .Where(d => d.Name.Contains(name) || d.Lastname.Contains(name));

            return result;
        }
    }
}
