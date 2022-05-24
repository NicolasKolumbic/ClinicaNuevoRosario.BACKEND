using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(CNRDBContext context) : base(context)
        {
        }

        public Task<IQueryable<Doctor>> GetByName(string name)
        {
            var doctors = this._context.Doctors;

            var result = (from d in doctors
                         where d.Name.Contains(name) || d.Lastname.Contains(name)
                         select d);

            return Task.FromResult(result);
        }
    }
}
