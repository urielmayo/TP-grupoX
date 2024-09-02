﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Commands
{
    public class CreateHumanPersonCommand : IRequest<CustomResponse<CreateCollaboratorResponse>>
    {
        public CreateHumanPersonRequest Request { get; set; }
        public CreateHumanPersonCommand(CreateHumanPersonRequest request)
        {
            Request = request;
        }
    }

    public class CreateHumanPersonCommandHandler : IRequestHandler<CreateHumanPersonCommand, CustomResponse<CreateCollaboratorResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        public CreateHumanPersonCommandHandler(IMapper mapper, 
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CustomResponse<CreateCollaboratorResponse>> Handle(CreateHumanPersonCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<HumanPerson>(command.Request);
       
            var passwordResults = await Task.WhenAll( _userManager.PasswordValidators
                .Select(validator => validator.ValidateAsync(_userManager, entity, command.Request.Password)));

            var errors = passwordResults
                    .Where(result => !result.Succeeded)
                    .SelectMany(result => result.Errors)
                    .ToList();

            if (errors.Any())
            {
                throw new ValidationPasswordException("La contraseña no cumple con los requisitos de seguridad", errors);
            }

            var result = await _userManager.CreateAsync(entity, command.Request.Password);

            if (!result.Succeeded)
            {
                throw new ApiCustomException(result.Errors.FirstOrDefault()?.Description ?? "Error Registrando Usuario", HttpStatusCode.InternalServerError);
            }

            await _userManager.AddToRoleAsync(entity, "Collaborator");

            var responsedTO= new CreateCollaboratorResponse()
              {
                 Id = entity.Id,
                 UserName = entity.UserName,
                 Email = entity.Email,
                 PhoneNumber = entity.PhoneNumber
              };

            return new CustomResponse<CreateCollaboratorResponse>("Se ha creado el colaborador",responsedTO);
        }
    }
}


