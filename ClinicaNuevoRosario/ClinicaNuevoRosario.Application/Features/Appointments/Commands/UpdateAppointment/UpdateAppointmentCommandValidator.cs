using FluentValidation;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandValidator: AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(x => x.Time)
               .NotNull().WithMessage($"El campo horario es un campo obligatorio");

            RuleFor(x => x.DoctorId)
                .NotNull()
                .GreaterThan(0).WithMessage($"Se debe definir un médico.");

            RuleFor(x => x.PatientId)
                .NotNull()
                .GreaterThan(0).WithMessage($"Se debe definir un paciente.");
        }
    }
}
