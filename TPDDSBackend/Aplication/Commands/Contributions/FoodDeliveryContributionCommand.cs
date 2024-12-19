using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IGenericRepository<FoodXDelivery> _foodXDeliveryRepository;
        private readonly IFridgeRepository _fridgeRepository;
        private readonly UserManager<Collaborator> _userManager;
        public FoodDeliveryContributionCommandHandler(IMapper mapper,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<FoodDelivery> foodDeliveryRepository,
            IGenericRepository<FoodXDelivery> foodXDeliveryRepository,
            IFridgeRepository fridgeRepository,
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _foodDeliveryRepository = foodDeliveryRepository;
            _fridgeRepository = fridgeRepository;
            _userManager = userManager;
            _foodXDeliveryRepository = foodXDeliveryRepository;
        }
        public async Task<CustomResponse<Contribution>> Handle(FoodDeliveryContributionCommand command, CancellationToken cancellationToken)
        {

            var originFridge = _fridgeRepository.GetById(command.Request.OriginFridgeId);        
            if (originFridge == null)
            {
                throw new ApiCustomException("No existe esa heladera de origen", HttpStatusCode.BadRequest);
            }

            var destinationFridge = _fridgeRepository.GetById(command.Request.DestinationFridgeId);
            if (destinationFridge == null)
            {
                throw new ApiCustomException("No existe esa heladera de destino", HttpStatusCode.BadRequest);
            }

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var collaborator = await _userManager.FindByIdAsync(collaboradorId);

            if (collaborator?.Address is null)
                throw new ApiCustomException(ServiceConstans.AddressRequiredMessage, HttpStatusCode.BadRequest);

            var foodDelivery = _mapper.Map<FoodDelivery>(command.Request);

            foodDelivery.CollaboratorId = collaboradorId;

            var foods = await _fridgeRepository.GetFoodsByFridge(command.Request.OriginFridgeId);

            if(foods.Count < command.Request.Amount)
            {
                throw new ApiCustomException("No hay esa cantidad de viandas en la heladera de origen", HttpStatusCode.BadRequest);
            }
            await _foodDeliveryRepository.Insert(foodDelivery);
            foreach (var food in foods)
            {
                food.FridgeId = command.Request.DestinationFridgeId;
                var foodXDelivery = new FoodXDelivery()
                {
                    FoodId = food.Id,
                    DeliveryId = foodDelivery.Id
                };
                await _foodXDeliveryRepository.Insert(foodXDelivery);
            }

            return new CustomResponse<Contribution>(ServiceConstans.MessageSuccessDonation);
        }
    }
}
