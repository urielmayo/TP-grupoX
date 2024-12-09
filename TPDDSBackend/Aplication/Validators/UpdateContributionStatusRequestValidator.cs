using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Validators
{
    public class UpdateContributionStatusRequestValidator: AbstractValidator<UpdateRequestContributionRequest>
    {
        public UpdateContributionStatusRequestValidator()
        {
          
            RuleFor(x => x.NewState)
                .Must(BeAValidEnum<ContributionStatus>)
                .WithMessage("Estado de contribucion invalida. Por favor usa una de las siguientes: Done, Canceled.");
        }

        private bool BeAValidEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }
    }
}
