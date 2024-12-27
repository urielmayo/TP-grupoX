using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Collaborators
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
        private readonly IGenericRepository<Card> _cardRepository;
        private readonly IGenericRepository<CollaboratorCard> _collaboratorCardRepository;
        public CreateHumanPersonCommandHandler(IMapper mapper,
            UserManager<Collaborator> userManager,
            IGenericRepository<Card> cardRepository,
            IGenericRepository<CollaboratorCard> collaboratorCardRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _cardRepository = cardRepository;
            _collaboratorCardRepository = collaboratorCardRepository;
        }

        public async Task<CustomResponse<CreateCollaboratorResponse>> Handle(CreateHumanPersonCommand command, CancellationToken ct)
        {
            var person = _mapper.Map<HumanPerson>(command.Request);

            var passwordResults = await Task.WhenAll(_userManager.PasswordValidators
                .Select(validator => validator.ValidateAsync(_userManager, person, command.Request.Password)));

            var errors = passwordResults
                    .Where(result => !result.Succeeded)
                    .SelectMany(result => result.Errors)
                    .ToList();

            if (errors.Any())
            {
                throw new ValidationPasswordException("La contraseña no cumple con los requisitos de seguridad", errors);
            }

            var result = await _userManager.CreateAsync(person, command.Request.Password);

            if (!result.Succeeded)
            {
                throw new ApiCustomException(result.Errors.FirstOrDefault()?.Description ?? "Error Registrando Usuario", HttpStatusCode.InternalServerError);
            }

            await _userManager.AddToRoleAsync(person, "Collaborator");

            var cardEntity = _mapper.Map<Card>(command.Request);

            await _cardRepository.Insert(cardEntity);

            await _collaboratorCardRepository.Insert(new CollaboratorCard()
            {
                CardId = cardEntity.Id,
                CollaboratorId = person.Id,
                CreatedAt = DateTime.UtcNow
            });

            var responsedTO = new CreateCollaboratorResponse()
            {
                Id = person.Id,
                UserName = person.UserName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                CardCode = cardEntity.Code
            };

            return new CustomResponse<CreateCollaboratorResponse>("Se ha creado el colaborador", responsedTO);
        }
    }
}


