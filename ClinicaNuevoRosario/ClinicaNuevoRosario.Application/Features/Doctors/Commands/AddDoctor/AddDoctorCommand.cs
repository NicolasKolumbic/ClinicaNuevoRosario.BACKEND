using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommand: IRequest<int>
    {

        public DoctorDto Doctor { get; set; }
    }
}
