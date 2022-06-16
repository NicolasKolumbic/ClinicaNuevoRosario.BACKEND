using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetAllMedicalSpecialities
{
    public class GetAllMedicalSpecialitiesQuery: IRequest<List<MedicalSpeacialityResponse>>
    {
    }
}
