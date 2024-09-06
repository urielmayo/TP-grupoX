using FluentValidation;
using System.Globalization;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Validators
{
    public class MoneyDonationRequestValidator: AbstractValidator<MoneyDonationRequest>
    {
        public MoneyDonationRequestValidator()
        {
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("la razon social es obligatorio.")
                .GreaterThan(0).WithMessage("el monto tiene que ser positivo");

            RuleFor(x => x.Date)
                .Must(BeAValidDate)
                .WithMessage("formato invalido de fecha. Por favor usa el formato 'yyyy-MM-dd'");

            RuleFor(x => x.Frequency)
                .Must(BeAValidEnum<DonationFrequency>)
                .WithMessage("frecuencia invalida. Por favor usa una de las siguientes: None, Weekly, Monthly, Annually.");
        }
        private bool BeAValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        private bool BeAValidEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }
    }
}
