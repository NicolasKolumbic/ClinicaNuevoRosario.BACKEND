using FluentValidation;

namespace ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandValidator: AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(x => x.AppointmentId)
               .NotNull().WithMessage($"El ID es un campo obligatorio");

           
        }
    }
}
