using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace ClinicaNuevoRosario.Infrastructure.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(CNRDBContext context) : base(context)
        {
        }

        public async Task<IQueryable<Doctor>> GetAll()
        {
            return _context.Doctors
                    .Include(x => x.DoctorSchedules)
                    .Include(x => x.Plans)
                    .Include(x => x.MedicalSpecialties)
                    .Select(x => x);
        }

        public async Task<IQueryable<Doctor>> GetByMedicalSpeciality(int medicalSpecialityId)
        {
            var doctors = _context.Doctors
                                .Include(x => x.DoctorSchedules)
                                .Include(x => x.Plans)
                                .Include(x => x.MedicalSpecialties)
                                .Where(x => x.MedicalSpecialties.Any(sp => sp.Id == medicalSpecialityId))
                                .Select(x => x);

            return doctors;
        }

        public async Task<IQueryable<Doctor>> GetByMedicalSpecialityOrHealthInsurance(int? medicalSpecialityId, int? planId)
        {
            if(medicalSpecialityId > 0 && planId > 0)
            {
              return  _context.Doctors
                    .Include(x => x.DoctorSchedules)
                    .Include(x => x.MedicalSpecialties)
                    .Where(d => d.Plans.Any(p => p.Id == planId) && d.MedicalSpecialties.Any(ms => ms.Id == medicalSpecialityId));
            } else if(medicalSpecialityId > 0 && planId == 0)
            {
              return  _context.Doctors
                            .Include(x => x.DoctorSchedules)
                            .Include(x => x.MedicalSpecialties)
                            .Where(d => d.MedicalSpecialties.Any(ms => ms.Id == medicalSpecialityId));
            } else if(medicalSpecialityId == 0 && planId > 0)
            {
              return _context.Doctors
                            .Include(x => x.DoctorSchedules)
                            .Include(x => x.MedicalSpecialties)
                            .Where(d => d.Plans.Any(ms => ms.Id == planId));
            }

            return new List<Doctor>().AsQueryable();
        }

        public async Task<IQueryable<Doctor>> GetByName(string name)
        {
            var result = _context.Doctors
                .Include(x => x.DoctorSchedules)
                .Include(x => x.MedicalSpecialties)
                .Where(d => d.Name.Contains(name) || d.Lastname.Contains(name));


            return result;
        }

    }
}
