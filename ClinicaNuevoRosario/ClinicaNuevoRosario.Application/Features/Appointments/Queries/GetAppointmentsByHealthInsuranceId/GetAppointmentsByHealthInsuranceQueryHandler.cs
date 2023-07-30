using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.GetAppointmentsByHealthInsuranceId
{
    public class GetAppointmentsByHealthInsuranceQueryHandler : IRequestHandler<GetAppointmentsByHealthInsuranceQuery, List<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentsByHealthInsuranceQueryHandler(
            IAppointmentRepository appointmentRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDto>> Handle(GetAppointmentsByHealthInsuranceQuery request, CancellationToken cancellationToken)
        {
            var appointments = await this._appointmentRepository.GetAppointmentByHealthInsuranceId(request.HealthInsuranceId);
            var mappedAppointments = _mapper.Map<List<AppointmentDto>>(appointments);

            return mappedAppointments;
        }
    }
}
