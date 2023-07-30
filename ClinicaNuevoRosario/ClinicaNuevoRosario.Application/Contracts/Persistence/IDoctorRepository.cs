using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IDoctorRepository : IAsyncRepository<Doctor>
    {
        public Task<IQueryable<Doctor>> GetByName(string name);

        public Task<Doctor> GetDoctorByEmail(string email);

        public Task<IQueryable<Doctor>> GetByMedicalSpeciality(int medicalSpecialityId);

        public Task<IQueryable<Doctor>> GetByMedicalSpecialityOrHealthInsurance(int? medicalSpecialityId, int? planId);


        public Task<IQueryable<Doctor>> GetAll();


    }
}
