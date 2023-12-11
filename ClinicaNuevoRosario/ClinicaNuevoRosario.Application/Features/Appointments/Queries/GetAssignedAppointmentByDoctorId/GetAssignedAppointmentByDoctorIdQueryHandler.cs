using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GeAvailableAppointmentsByDoctorId
{
    public class GetAssignedAppointmentByDoctorIdQueryHandler : IRequestHandler<GetAssignedAppointmentByDoctorIdQuery, List<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAssignedAppointmentByDoctorIdQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentDto>> Handle(GetAssignedAppointmentByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAssignedAppointmentByDoctor(request.DoctorId);
            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments.ToList());
            return appointmentsDto;
        }
    }
}
