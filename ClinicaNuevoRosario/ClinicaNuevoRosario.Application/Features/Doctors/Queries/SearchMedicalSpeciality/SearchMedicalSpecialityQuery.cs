using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchMedicalSpeciality
{
    public class SearchMedicalSpecialityQuery: IRequest<List<MedicalSpecialtyDto>>
    {
        public string Text { get; set; }
    }
}
