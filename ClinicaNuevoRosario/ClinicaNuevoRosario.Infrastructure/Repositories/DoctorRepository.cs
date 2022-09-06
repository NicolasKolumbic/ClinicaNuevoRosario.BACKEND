using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
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

        public async Task<IQueryable<Doctor>> GetAll()
        {
            return _context.Doctors
                    .Include(x => x.DoctorSchedules)
                    .Include(x => x.DoctorMedicalSpecialties)
                    .ThenInclude(x => x.MedicalSpecialty)
                    .Select(x => x);
        }

        public async Task<IQueryable<Doctor>> GetByMedicalSpeciality(int medicalSpecialityId)
        {
            var doctors = _context.Doctors
                                .Include(x => x.DoctorSchedules)
                                .Include(x => x.DoctorMedicalSpecialties)
                                .ThenInclude(x => x.MedicalSpecialty)
                                .Where(x => x.DoctorMedicalSpecialties.Any(sp => sp.MedicalSpecialtyId == medicalSpecialityId))
                                .Select(x => x);

            return doctors;
        }

        public async Task<IQueryable<Doctor>> GetByName(string name)
        {
            var result = _context.Doctors
                .Include(x => x.DoctorSchedules)
                .Include(x => x.DoctorMedicalSpecialties)
                .ThenInclude(x => x.MedicalSpecialty)
                .Where(d => d.Name.Contains(name) || d.Lastname.Contains(name));


            return result;
        }

    }
}
