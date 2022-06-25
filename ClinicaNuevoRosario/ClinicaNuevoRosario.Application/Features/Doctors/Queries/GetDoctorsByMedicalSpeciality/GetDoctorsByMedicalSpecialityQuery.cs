using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetDoctorsByMedicalSpeciality
{
    public class GetDoctorsByMedicalSpecialityQuery: IRequest<List<DoctorDto>>
    {
        public int MedicalSpecialityId { get; set; }
    }
}
