using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByDoctor
{
    public class GetAppointmentsByDoctorQuery: IRequest<List<AppointmentDto>>
    {
        public int DoctorId { get; set; }
    }
}
