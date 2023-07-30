using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(request.AppointmentId);
            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
