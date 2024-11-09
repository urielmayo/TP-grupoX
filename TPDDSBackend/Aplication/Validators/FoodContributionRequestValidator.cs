using FluentValidation;
using System.Globalization;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Validators
{
    public class FoodContributionRequestValidator : AbstractValidator<FoodContributionRequest>
    {
        public FoodContributionRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("la Descripcion es obligatoria.");


            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("la fecha de expiracion es obligatoria.")
                .Must(BeAValidDate)
                .WithMessage("formato invalido de fecha. Por favor usa el formato 'yyyy-MM-dd'");
        }
        private bool BeAValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
