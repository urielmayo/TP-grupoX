using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateFridgeSubscriptionRequestValidator: AbstractValidator<CreateFridgeSubscriptionRequest>
    {
        public CreateFridgeSubscriptionRequestValidator()
        {
            RuleFor(x => x.FridgeId)
                .NotEmpty().WithMessage("el id de la heladera es obligatorio");

            RuleFor(x => x.CommunicationMedia)
                            .Must(BeAValidEnum<CommunicationMediaName>)
                            .WithMessage("nombre de medio de comunicacion invalida." +
                            "Por favor usa una de las siguientes: Mail, WhatsApp, Telegram.");
        }

        private bool BeAValidEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }
    }
}
