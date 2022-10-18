using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchDoctors
{
    public class SearchDoctorsQuery: IRequest<List<DoctorDto>>
    {
        public string? DoctorCriteria { get; set; }
        public SearchDoctorPlanDto? Plan { get; set; }
        public MedicalSpecialtyDto? MedicalSpecialty { get; set; }
    }
}
