using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByEmailQuery: IRequest<DoctorDto>
    {
        public string Email { get; set; }
    }
}
