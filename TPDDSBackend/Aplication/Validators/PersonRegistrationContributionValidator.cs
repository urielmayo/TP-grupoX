using FluentValidation;
using System.Linq;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class PersonRegistrationContributionValidator: AbstractValidator<PersonRegistrationContributionRequest>
    {
        public PersonRegistrationContributionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("E nombre de la persona a registrar es obligatorio.");
        }
    }
}
