using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQuery: IRequest<List<AppointmentDto>>
    {

    }
}
