using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateHumanPersonRequestValidator: AbstractValidator<CreateHumanPersonRequest>
    {
        public CreateHumanPersonRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage("El apellido es obligatorio.");

            RuleFor(x => x)
                .Must(HaveAtLeastOneContactMethod)
                .WithMessage("Debe proporcionar al menos un medio de contacto (Email o Teléfono).");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.");

        }

        private bool HaveAtLeastOneContactMethod(CreateHumanPersonRequest request)
        {
            return !string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.PhoneNumber);
        }
    }
}
