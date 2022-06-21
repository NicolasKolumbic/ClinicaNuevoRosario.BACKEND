using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(CNRDBContext context) : base(context)
        {
        }

        public async Task<IQueryable<DoctorMedicalSpecialty>> GetByMedicalSpeciality(int medicalSpecialityId)
        {
            var doctorMedicalSpecialities =  this._context.DoctorMedicalSpecialties
                                       .Include(m => m.Doctor)
                                       .Include(dms => dms.MedicalSpecialty)
                                       .Where(x => x.MedicalSpecialtyId == medicalSpecialityId)
                                       .Select(x => x);

            return doctorMedicalSpecialities;
        }

        public async Task<IQueryable<DoctorMedicalSpecialty>> GetByName(string name)
        {
            var doctorMedicalSpecialities = this._context.DoctorMedicalSpecialties
                                                         .Include(dms => dms.MedicalSpecialty)
                                                         .Include(dms => dms.Doctor);

            var result = (from dms in doctorMedicalSpecialities
                          where dms.Doctor.Name.Contains(name) || dms.Doctor.Lastname.Contains(name)
                         select dms);

            return result;
        }
    }
}
