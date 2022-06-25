using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByDoctor
{
    public class GetAppointmentsByDoctorQueryHandler : IRequestHandler<GetAppointmentsByDoctorQuery, List<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentsByDoctorQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDto>> Handle(GetAppointmentsByDoctorQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetByDoctorId(request.DoctorId);
            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments.ToList());
            return appointmentsDto;
        }
    }
}
