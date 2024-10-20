using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class FoodDeliveryRequestValidator: AbstractValidator<FoodDeliveryContributionRequest>
    {
        public FoodDeliveryRequestValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("el monto es obligatorio.")
                .GreaterThan(0).WithMessage("el monto tiene que ser positivo");
        }
    }
}
