using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateFridgeAlertRequestValidator: AbstractValidator<CreateFridgeAlertRequest>
    {
        public CreateFridgeAlertRequestValidator()
        {
            RuleFor(x => x.FridgeId)
           .NotEmpty()
           .WithMessage("id de heladera obligatorio");

            RuleFor(x => x.Type)
                .Must(BeAValidEnum<TypeFridgeAlert>)
                .WithMessage("Tipo de alerta invalida. Por favor usa una de las siguientes: " +
                "Temperature, Fraud, ConnectionFailure");
        }

        private bool BeAValidEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }
    }
}
