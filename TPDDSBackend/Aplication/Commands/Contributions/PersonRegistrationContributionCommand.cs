using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
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
        private readonly IGenericRepository<VulnerablePersonCard> _vulnerablePersonCardRepository;
        private readonly IGenericRepository<Card> _cardRepository;
        private readonly IDocumentTypeRepository _documentypeRepository;
        private readonly UserManager<Collaborator> _userManager;
        public PersonRegistrationContributionCommandHandler(IMapper mapper,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<PersonInVulnerableSituation> personRepository,
            IGenericRepository<VulnerablePersonCard> vulnerablePersonCardRepository,
            IGenericRepository<Card> cardRepository,
            UserManager<Collaborator> userManager,
            IDocumentTypeRepository documentypeRepository
            )
        {
            _mapper = mapper;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _vulnerablePersonCardRepository = vulnerablePersonCardRepository;
            _cardRepository = cardRepository;
            _userManager = userManager;
            _personRepository = personRepository;
            _documentypeRepository = documentypeRepository;
        }
        public async Task<CustomResponse<Contribution>> Handle(PersonRegistrationContributionCommand command, CancellationToken cancellationToken)
        {

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var collaborator = await _userManager.FindByIdAsync(collaboradorId);

            if (collaborator?.Address is null)
                throw new ApiCustomException(ServiceConstans.AddressRequiredMessage, HttpStatusCode.BadRequest);


            var person = _mapper.Map<PersonInVulnerableSituation>(command.Request);
            
            if (command.Request?.DocumentType is not null)
            {
                var documentType = await _documentypeRepository.GetByDescription(command.Request.DocumentType);
                person.DocumentType = documentType;
            }


            await _personRepository.Insert(person);

            var card = new Card()
            {
                Code = command.Request!.CardCode
            };

            await _cardRepository.Insert(card);

            var vulnerablePersonCard = new VulnerablePersonCard()
            {
                CollaboratorId = collaboradorId,
                PersonInVulnerableSituationId = person.Id,
                CardId = card.Id,
                Date = DateTime.UtcNow,
            };
            
            await _vulnerablePersonCardRepository.Insert(vulnerablePersonCard);

            return new CustomResponse<Contribution>(ServiceConstans.MessageSuccessDonation);
        }
    }
}
