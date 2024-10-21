using FluentValidation;
using System.Linq;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class PersonRegistrationContributionValidator: AbstractValidator<PersonRegistrationContributionRequest>
    {
        public PersonRegistrationContributionValidator()
        {
            RuleFor(x => x.CardCode)
                .NotEmpty().WithMessage("El codigo de la tarjeta es obligatorio.")
                .Length(11).WithMessage("El codigo de la tarjeta tiene que ser de 11 caracteres");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("E nombre de la persona a registrar es obligatorio.");
        }
    }
}
