﻿using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Aplication.Dtos.Requests;

namespace TPDDSBackend.Aplication.Validators
{
    public class CreateHumanPersonRequestValidator: AbstractValidator<CreateHumanPersonRequest>
    {
        public CreateHumanPersonRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage("El apellido es obligatorio.");

            RuleFor(x => x)
                .Must(HaveAtLeastOneContactMethod)
                .WithMessage("Debe proporcionar al menos un medio de contacto (Email o Teléfono).");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.");
               
        }

        private bool HaveAtLeastOneContactMethod(CreateHumanPersonRequest request)
        {
            return !string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.PhoneNumber);
        }

        //private async Task<bool> BeAValidPassword(string password, CancellationToken cancellationToken)
        //{
        //    var testUser = new IdentityUser();
        //    var passwordResult = await _userManager.PasswordValidators.First().ValidateAsync(_userManager, testUser, password);

        //    return passwordResult.Succeeded;
        //}
    }
}
