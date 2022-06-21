using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.SearchMedicalSpeciality
{
    public class SearchMedicalSpecialityQuery: IRequest<List<MedicalSpeacialityResponse>>
    {
        public string Text { get; set; }
    }
}
