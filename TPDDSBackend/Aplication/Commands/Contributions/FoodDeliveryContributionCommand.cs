using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class FoodDeliveryContributionCommand: IRequest<CustomResponse<Contribution>>
    {
        public FoodDeliveryContributionRequest Request { get; set; }
        public FoodDeliveryContributionCommand(FoodDeliveryContributionRequest request) 
        {
            Request = request;
        }
    }

    public class FoodDeliveryContributionCommandHandler : IRequestHandler<FoodDeliveryContributionCommand, CustomResponse<Contribution>>
    {
        private readonly IMapper _mapper;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<FoodDelivery> _foodDeliveryRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        public FoodDeliveryContributionCommandHandler(IMapper mapper,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<FoodDelivery> foodDeliveryRepository,
            IGenericRepository<Fridge> fridgeRepository)
        {
            _mapper = mapper;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _foodDeliveryRepository = foodDeliveryRepository;
            _fridgeRepository = fridgeRepository;
        }
        public async Task<CustomResponse<Contribution>> Handle(FoodDeliveryContributionCommand command, CancellationToken cancellationToken)
        {

            var originFridge = _fridgeRepository.GetById(command.Request.OriginFridgeId);        
            if (originFridge == null)
            {
                throw new ApiCustomException("No existe esa heladera de origen", HttpStatusCode.BadRequest);
            }

            var destinationFridgeId = _fridgeRepository.GetById(command.Request.DestinationFridgeId);
            if (destinationFridgeId == null)
            {
                throw new ApiCustomException("No existe esa heladera de destino", HttpStatusCode.BadRequest);
            }

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var foodDelivery = _mapper.Map<FoodDelivery>(command.Request);

            foodDelivery.CollaboratorId = collaboradorId;

            await _foodDeliveryRepository.Insert(foodDelivery);

            return new CustomResponse<Contribution>(ServiceConstans.MessageSuccessDonation);
        }
    }
}
