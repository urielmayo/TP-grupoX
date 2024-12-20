using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Commands.Contributions;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class OpenFridgeCommand : IRequest<Unit>
    {
        public OpeningRequest Request { get; set; }
        public OpenFridgeCommand(OpeningRequest request)
        {
            Request = request;
        }
    }

    public class OpenFridgeCommandHandler : IRequestHandler<OpenFridgeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<FridgeOpening> _fridgeOpeningRepository;
        private readonly IGenericRepository<Card> _cardRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        private readonly IContributionRepository _contributionRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public OpenFridgeCommandHandler(IMapper mapper,
            IGenericRepository<FridgeOpening> fridgeOpeningRepository,
            IGenericRepository<Card> cardRepository,
            IGenericRepository<Fridge> fridgeRepository,
            IContributionRepository contributionRepository,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator)
        {
            _mapper = mapper;
            _fridgeOpeningRepository = fridgeOpeningRepository;
            _fridgeRepository = fridgeRepository;
            _cardRepository = cardRepository;    
            _contributionRepository = contributionRepository;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(OpenFridgeCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(command.Request.FridgeId);

            if (fridge == null)
                throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);

            var card = await _cardRepository.GetById(command.Request.CardId);

            if (card == null)
                throw new ApiCustomException("Tarjeta no encontrada", HttpStatusCode.NotFound);

            var entity = _mapper.Map<FridgeOpening>(command.Request);  
                    
            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var contribution = await _contributionRepository.GetRequestedContribution(collaboradorId, fridge.Id);

            if (contribution == null)
                throw new ApiCustomException("No se encontro una solicitud para esa heladera", HttpStatusCode.NotFound);

            var request = new UpdateRequestContributionRequest() { NewState = "Done" };
           if (contribution.Discriminator == "FoodDonation")
           {
              await _mediator.Send(new UpdateFoodDonationCommand(request, contribution.Id));
           }
           else
           {
              await _mediator.Send(new UpdateFoodDeliveryCommand(request, contribution.Id));
           }            

            await _fridgeOpeningRepository.Insert(entity);

            return Unit.Value;
        }
    }
}


