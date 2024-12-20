using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Validators
{
    public class OpeningRequestValidator : AbstractValidator<OpeningRequest>
    {
        public OpeningRequestValidator()
        {

            RuleFor(x => x.FridgeId)
                .NotEmpty().WithMessage("El id de heladera es obligatoria.");

            RuleFor(x => x.CardId)
                .NotEmpty().WithMessage("El id de tarjeta es obligatoria."); 

            RuleFor(x => x.OpeningFor)
                 .Must(BeAValidEnum<OpeningFor>)
                 .WithMessage("OpeningFor invalido. Por favor usa una de las siguientes: EnterFood, TakeOutFood.");
        }

        private bool BeAValidEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }
    }
}
