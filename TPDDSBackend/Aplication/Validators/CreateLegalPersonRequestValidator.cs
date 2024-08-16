using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateLegalPersonRequestValidator : AbstractValidator<CreateLegalPersonRequest>
    {
        public CreateLegalPersonRequestValidator()
        {

            RuleFor(x => x.BusinessName)
                .NotEmpty().WithMessage("la razon social es obligatorio.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("El tipo de organizacion es obligatorio.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("El rubro es obligatoria.");

            RuleFor(x => x)
                .Must(HaveAtLeastOneContactMethod)
                .WithMessage("Debe proporcionar al menos un medio de contacto (Email o Teléfono).");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.");
              
        }

        private bool HaveAtLeastOneContactMethod(CreateLegalPersonRequest request)
        {
            return !string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.PhoneNumber);
        }
        //private async Task<bool> BeAValidPassword(string password, CancellationToken cancellationToken)
        //{
        //    var testUser = new IdentityUser(); // Usuario temporal solo para la validación
        //    var passwordResult = await _userManager.PasswordValidators.First().ValidateAsync(_userManager, testUser, password);

        //    return passwordResult.Succeeded;
        //}
    }
}
