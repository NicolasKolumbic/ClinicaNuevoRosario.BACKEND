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
            var pantient = this._context.Patients;

            var result = (from p in pantient
                          where p.Name.Contains(name) || p.Lastname.Contains(name)
                          select p);

            return result;
        }
    }
}
