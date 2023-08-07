using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Exceptions;
using ClinicaNuevoRosario.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment
{

    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAppointmentCommandHandler> _logger;

        public UpdateAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository,
            IMedicalHistoryRepository medicalHistoryRepository,
            IMapper mapper,
            ILogger<UpdateAppointmentCommandHandler> logger
            )
        {
            _appointmentRepository = appointmentRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(request.AppointmentId);
            if (appointment == null)
            {
                _logger.LogError($"No se encontrado el una persona con id: {request.AppointmentId}");
                throw new NotFoundException(nameof(Appointment), request.AppointmentId);
            }
            if(request.MedicalHistoryComment != null)
            {
                var medicalHistory = new MedicalHistory();
                medicalHistory.Comments = request.MedicalHistoryComment;
                medicalHistory.Doctor = appointment.Doctor;
                medicalHistory.Patient = appointment.Patient;
                await this._medicalHistoryRepository.AddAsync(medicalHistory);
            }
           
            appointment.AppointmentStateId = (int)request.AppointmentState;
            var updatedAppointment = await _appointmentRepository.UpdateAsync(appointment);
            _logger.LogInformation($"Cita: {updatedAppointment} fue actualizado correctamente");

            return updatedAppointment.Id;
        }
    }
}
