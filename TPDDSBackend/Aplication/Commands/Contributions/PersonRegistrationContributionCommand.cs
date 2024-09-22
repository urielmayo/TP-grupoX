using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class PersonRegistrationContributionCommand: IRequest<CustomResponse<Contribution>>
    {
        public PersonRegistrationContributionRequest? Request { get; set; }
        public PersonRegistrationContributionCommand(PersonRegistrationContributionRequest? request)
        {
            Request = request;
        }
    }

    public class PersonRegistrationContributionCommandHandler : IRequestHandler<PersonRegistrationContributionCommand, CustomResponse<Contribution>>
    {
        private readonly IMapper _mapper;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<PersonInVulnerableSituation> _personRepository;
        private readonly IGenericRepository<Card> _cardRepository;
        private readonly UserManager<Collaborator> _userManager;
        public PersonRegistrationContributionCommandHandler(IMapper mapper,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<PersonInVulnerableSituation> personRepository,
            IGenericRepository<Card> cardRepository,
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _cardRepository = cardRepository;
            _userManager = userManager;
        }
        public async Task<CustomResponse<Contribution>> Handle(PersonRegistrationContributionCommand command, CancellationToken cancellationToken)
        {

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var collaborator = await _userManager.FindByIdAsync(collaboradorId);

            if (collaborator?.Address is null)
                throw new ApiCustomException("El colaborador debe tener una direccion registrada", HttpStatusCode.BadRequest);


            var person = _mapper.Map<PersonInVulnerableSituation>(command.Request);
            
            await _personRepository.Insert(person);

            var card = _mapper.Map<Card>(command.Request);
            card.CollaboratorId = collaboradorId;
            card.PersonInVulnerableSituationId = person.Id;
            card.Date = DateTime.UtcNow;
            
            await _cardRepository.Insert(card);

            return new CustomResponse<Contribution>("Se ha registrado con exito la persona con su tarjeta");
        }
    }
}
