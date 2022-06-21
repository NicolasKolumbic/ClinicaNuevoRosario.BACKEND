using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IDoctorRepository: IAsyncRepository<Doctor>
    {
       public Task<IQueryable<DoctorMedicalSpecialty>> GetByName(string name);

        public Task<IQueryable<DoctorMedicalSpecialty>> GetByMedicalSpeciality(int medicalSpecialityId);
    }
}
