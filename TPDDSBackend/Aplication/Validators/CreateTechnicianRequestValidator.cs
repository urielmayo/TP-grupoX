using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateTechnicianRequestValidator : AbstractValidator<CreateTechnicianRequest>
    {
        public CreateTechnicianRequestValidator()
        {

            //RuleFor(x => x.Name)
            //    .NotEmpty().WithMessage("El nombre es un dato obligatorio");

            //RuleFor(x => x.Surname)
            //    .NotEmpty().WithMessage("El apellido es un dato obligatorio");

            //RuleFor(x => x.WorkerIdentificationNumber)
            //    .NotEmpty().WithMessage("El CUIL es un dato obligatorio");

            //RuleFor(x => x.NeighborhoodId)
            //    .NotEmpty().WithMessage("El barrio es un dato obligatorio");

            //RuleFor(x => x.DocumentTypeId)
            //    .NotEmpty().WithMessage("El tipo de documento es un dato obligatorio");

            //RuleFor(x => x.IdNumber)
            //    .NotEmpty().WithMessage("El número de documento es un dato obligatorio");


            RuleFor(x => x)
                .Must(HaveAtLeastOneContactMethod)
                .WithMessage("Debe proporcionar al menos un medio de contacto (Email o Teléfono).");

        }

        private bool HaveAtLeastOneContactMethod(CreateTechnicianRequest request)
        {
            return !string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.PhoneNumber);
        }
    }
}
