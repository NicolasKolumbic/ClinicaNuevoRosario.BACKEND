using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByEmail
{
    public class GetAppointmentsByEmailQueryHandler: IRequestHandler<GetAppointmentsByEmailQuery, List<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentsByEmailQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentDto>> Handle(GetAppointmentsByEmailQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetByEmail(request.Email);
            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments.ToList());
            return appointmentsDto;
        }
    }
}
