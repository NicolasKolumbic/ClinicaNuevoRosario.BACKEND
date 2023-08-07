using AutoMapper;
using AutoMapper.Execution;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Application.Patterns.FilterBuilder;
using ClinicaNuevoRosario.Domain;
using MediatR;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Queries.AppointmentsFilter
{
    public class AppointmentsFilterQueryHandler : IRequestHandler<AppointmentsFilterQuery, List<AppointmentDto>>
    {

        private readonly IFilterBuilder _filterBuilder;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentsFilterQueryHandler(
            IAppointmentRepository appointmentRepository,
            IMapper mapper,
            IFilterBuilder filterBuilder)
        {
            _filterBuilder = filterBuilder;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<List<AppointmentDto>> Handle(AppointmentsFilterQuery request, CancellationToken cancellationToken)
        {
            var expression = _filterBuilder.BuildStartEndDateFilter(request.StartDate, request.EndDate)
                          .BuildDoctorFilter(request.DoctorId)
                          .BuildByMonthFilter(request.Month)
                          .BuildHealthInsuranceFilter(request.HealthInsuranceId)
                          .BuildMedicalSpecialityFilter(request.MedicalSpecialtyId)
                          .BuildAppointmentStateFilter(request.AppointmentState)
                          .BuildAppointmentTypeFilter(request.ServiceType)
                          .GetFilterExpression();

            var appointments = await this._appointmentRepository.Filter(expression);
            return _mapper.Map<List<AppointmentDto>>(appointments).ToList();


        }
    }
}
