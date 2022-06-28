using FluentValidation;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommandValidator : AbstractValidator<AddAppointmentCommand>
    {
        public AddAppointmentCommandValidator()
        {
            RuleFor(x => x.Time)
                .NotNull().WithMessage($"El campo horario es un campo obligatorio");

            RuleFor(x => x.Doctor.DoctorId)
                .NotNull()
                .GreaterThan(0).WithMessage($"Se debe definir un médico.");

            RuleFor(x => x.Patient.PatientId)
                .NotNull()
                .GreaterThan(0).WithMessage($"Se debe definir un paciente.");

        }
    }
    
}
