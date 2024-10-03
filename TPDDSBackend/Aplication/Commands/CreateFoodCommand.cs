using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Runtime.CompilerServices;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class CreateFoodCommand : IRequest<CustomResponse<CreateFoodResponse>>
    {
        public CreateFoodRequest Request { get; set; }
        public CreateFoodCommand(CreateFoodRequest request)
        {
            Request = request;
        }
    }

    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, CustomResponse<CreateFoodResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Food> _manager;
        private readonly IGenericRepository<Fridge> _fridgeManager;
        private readonly IGenericRepository<FoodState> _foodStateManager;
        private readonly UserManager<Collaborator> _userManager;


        public CreateFoodCommandHandler(IMapper mapper,
            IGenericRepository<Food> manager,
            IGenericRepository<Fridge> fridgeManager,
            UserManager<Collaborator> userManager,
            IGenericRepository<FoodState> foodStateManager)
        {
            _manager = manager;
            _fridgeManager = fridgeManager;
            _mapper = mapper;
            _userManager = userManager;
            _foodStateManager = foodStateManager;
        }

        public async Task<CustomResponse<CreateFoodResponse>> Handle(CreateFoodCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Food>(command.Request);


            var fridgeResult = await _fridgeManager.GetById(entity.FridgeId);
            if (fridgeResult == null)
                throw new ApiCustomException("No existe la heladera a la que se hace referencia", HttpStatusCode.NotFound);

            var user = await _userManager.FindByIdAsync(entity.DoneeId.ToString());
            if (user == null)
                throw new ApiCustomException("No existe el donante al que se hace referencia", HttpStatusCode.NotFound);

            var stateResult = await _foodStateManager.GetById(entity.StateId);
            if (stateResult == null)
                throw new ApiCustomException("No existe el estado al que se hace referencia", HttpStatusCode.NotFound);

            var result = await _manager.Insert(entity);
            if (result == null)
                {
                    throw new ApiCustomException("Error Registrando Vianda", HttpStatusCode.InternalServerError);
                }

            var responseDTO = new CreateFoodResponse()
            {
                Id = entity.Id,
                Description = entity.Description,
                Weight = entity.Weight,
                Calories = entity.Calories
            };

            return new CustomResponse<CreateFoodResponse>("Se ha creado la vianda", responseDTO);
        }
    }
}


