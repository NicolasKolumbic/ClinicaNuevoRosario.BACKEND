using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GeAvailableAppointmentsByDoctorId
{
    public class GetAssignedAppointmentByDoctorIdQuery: IRequest<List<AppointmentDto>>
    {
        public int DoctorId { get; set; }
    }
}
