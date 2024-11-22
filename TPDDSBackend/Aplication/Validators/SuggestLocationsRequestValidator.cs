using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class SuggestLocationsRequestValidator: AbstractValidator<SuggestFridgeLocationsRequest>
    {
        public SuggestLocationsRequestValidator()
        {
            RuleFor(x => x.RadiusInKm)
                .GreaterThan(0).WithMessage("El radio es obligatorio");

            RuleFor(x => x.NumberOfPoints)
                 .GreaterThan(0).WithMessage("El numero de puntos es obligatorio");
               
        }
    }
}
