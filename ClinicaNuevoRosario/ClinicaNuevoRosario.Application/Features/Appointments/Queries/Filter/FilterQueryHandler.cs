using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;
using MediatR;
using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.Filter
{
    public class FilterQueryHandler : IRequestHandler<FilterQuery, List<AppointmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public FilterQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        async Task<List<AppointmentDto>> IRequestHandler<FilterQuery, List<AppointmentDto>>.Handle(FilterQuery request, CancellationToken cancellationToken)
        {

                var appointments = _appointmentRepository.GetAsync(x => x.Patient.Plan.HealthInsurance.Id == request.HealthInsuranceId);
                return _mapper.Map<List<AppointmentDto>>(appointments);
            
        }
    }
}
