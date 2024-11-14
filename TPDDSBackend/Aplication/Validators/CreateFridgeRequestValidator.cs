using FluentValidation;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateFridgeRequestValidator : AbstractValidator<CreateFridgeRequest>
    {
        public CreateFridgeRequestValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("la direccion es obligatoria.");

            RuleFor(x => x.MaxFoodCapacity)
                .NotEmpty().WithMessage("la capacidad maxima es obligatoria.")
                .GreaterThan(0).WithMessage("la capacidad maxima tiene que ser mayor a 0");

            RuleFor(x => x.Latitud)
                .NotEmpty().WithMessage("la Latitud es obligatoria.");

            RuleFor(x => x.Longitud)
                .NotEmpty().WithMessage("la Longitud es obligatoria.");

        }

    }
}
