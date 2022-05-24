using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand: IRequest<int>
    {
        public int DoctorId { get; set; }
    }
}
