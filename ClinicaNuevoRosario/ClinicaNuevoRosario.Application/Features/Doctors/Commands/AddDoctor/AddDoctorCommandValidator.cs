using FluentValidation;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommandValidator: AbstractValidator<AddDoctorCommand>
    {
        public AddDoctorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"Campo Requerido, el campo \"Nombre\" debe ser definido ")
                .NotNull()
                .MaximumLength(50).WithMessage("el campo \"Nombre\" no puede exceder los 50 caracteres");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage($"Campo Requerido, el campo \"Apellido\" debe ser definido ")
                .NotNull()
                .MaximumLength(50).WithMessage("el campo \"Apellido\" no puede exceder los 50 caracteres");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage($"Campo Requerido, el campo \"Teléfono\" debe ser definido ")
                .NotNull()
                .Length(13).WithMessage($"EL formato del \"Teléfono\" es incorrecto ");

            RuleFor(x => x.IdentificationNumber)
               .NotEmpty().WithMessage($"Campo Requerido, el campo \"DNI\" debe ser definido ")
               .NotNull()
               .Length(7,8).WithMessage($"EL formato del \"DNI\" es incorrecto ");

            RuleFor(x => x.MedicalLicense)
               .NotEmpty().WithMessage($"Campo Requerido, el campo \"Matrícula\" debe ser definido ")
               .NotNull()
               .Length(4,5).WithMessage($"EL formato de la \"Matrícula\" es incorrecta ");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage($"Campo Requerido, el campo \"Email\" debe ser definido ")
               .NotNull()
               .EmailAddress().WithMessage($"EL formato del \"Email\" es incorrecto ");

        }
    }
}
