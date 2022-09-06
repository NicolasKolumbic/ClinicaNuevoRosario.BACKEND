using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQuery: IRequest<List<DoctorDto>>
    {
    }
}
