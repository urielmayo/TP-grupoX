using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class CreateFridgeSubscriptionCommand : IRequest<CustomResponse<CreateFridgeSubscriptionResponse>>
    {
        public CreateFridgeSubscriptionRequest Request { get; set; }
        public CreateFridgeSubscriptionCommand(CreateFridgeSubscriptionRequest request)
        {
            Request = request;
        }
    }

    public class CreateFridgeSubscriptionCommandHandler : IRequestHandler<CreateFridgeSubscriptionCommand, CustomResponse<CreateFridgeSubscriptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommunicationMediaRepository _communicationMediaRepository;
        private readonly IGenericRepository<FridgeSubscription> _fridgeSubscriptionRepository;

        public CreateFridgeSubscriptionCommandHandler(IMapper mapper, 
            IGenericRepository<Fridge> fridgeRepository,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            ICommunicationMediaRepository communicationMediaRepository,
            IGenericRepository<FridgeSubscription> fridgeSubscriptionRepository)
        {
            _mapper = mapper;
            _fridgeRepository = fridgeRepository;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _communicationMediaRepository = communicationMediaRepository;
            _fridgeSubscriptionRepository = fridgeSubscriptionRepository;
        }

        public async Task<CustomResponse<CreateFridgeSubscriptionResponse>> Handle(CreateFridgeSubscriptionCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(command.Request.FridgeId);

            if (fridge == null)
                throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);

            var entity = _mapper.Map<FridgeSubscription>(command.Request);

            var communicationMediaName = (CommunicationMediaName)Enum.Parse(typeof(CommunicationMediaName), command.Request.CommunicationMedia);

            var media = await _communicationMediaRepository.GetByName(communicationMediaName);

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            entity.CollaboratorId = collaboradorId;
            entity.CommunicationMediaId = media.Id;

            await _fridgeSubscriptionRepository.Insert(entity);

            var response = _mapper.Map<CreateFridgeSubscriptionResponse>(entity);

            return new CustomResponse<CreateFridgeSubscriptionResponse>("Se ha creado una nueva suscripcion de heladera", response);
        }
    }
}


